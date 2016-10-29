using System;
using System.Threading;
using System.Windows.Input;
using Presentation.Interfaces;

namespace Presentation.Commands
{
    /// <summary>
    /// An <see cref="ICommand"/> whose delegates can be attached for <see cref="Execute"/> and <see cref="CanExecute"/>
    /// </summary>
    public sealed class DelegateCommand<T> : IRaiseableCommand
    {
        private readonly SynchronizationContext _synchronizationContext;
        private readonly Action<T> _executeMethod;
        private readonly Func<T, bool> _canExecuteMethod;

        public DelegateCommand(Action<T> executeMethod) : this(executeMethod, _ => true)
        {
        }

        public DelegateCommand(Action<T> executeMethod, Func<T, bool> canExecuteMethod)
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
            _executeMethod((T)parameter);
        }

        /// <inheritdoc />
        public bool CanExecute(object parameter)
        {
            return _canExecuteMethod == null || _canExecuteMethod((T)parameter);
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