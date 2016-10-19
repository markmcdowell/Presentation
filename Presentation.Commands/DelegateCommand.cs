using System;
using System.Threading;
using System.Windows.Input;

namespace Presentation.Commands
{
    /// <summary>
    /// An <see cref="ICommand"/> whose delegates can be attached for <see cref="Execute"/> and <see cref="CanExecute"/>
    /// </summary>
    public sealed class DelegateCommand : IRaiseableCommand
    {
        private readonly SynchronizationContext _synchronizationContext;
        private readonly Action _executeMethod;
        private readonly Func<bool> _canExecuteMethod;

        public DelegateCommand(Action executeMethod) : this(executeMethod, () => true)
        {
        }

        public DelegateCommand(Action executeMethod, Func<bool> canExecuteMethod)
        {
            if (executeMethod == null || canExecuteMethod == null)
                throw new ArgumentNullException(nameof(executeMethod));

            _executeMethod = executeMethod;
            _canExecuteMethod = canExecuteMethod;
            _synchronizationContext = SynchronizationContext.Current;
        }

        public event EventHandler CanExecuteChanged;

        /// <inheritdoc />
        public void Execute(object parameter)
        {
            _executeMethod();
        }

        /// <inheritdoc />
        public bool CanExecute(object parameter)
        {
            return _canExecuteMethod == null || _canExecuteMethod();
        }

        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler == null)
                return;

            if (_synchronizationContext != null && _synchronizationContext != SynchronizationContext.Current)
                _synchronizationContext.Post(o => handler.Invoke(this, EventArgs.Empty), null);
            else
                handler.Invoke(this, EventArgs.Empty);
        }
    }
}
