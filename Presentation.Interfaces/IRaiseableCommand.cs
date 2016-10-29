using System.Windows.Input;

namespace Presentation.Interfaces
{
    public interface IRaiseableCommand : ICommand
    {
        /// <summary>
        /// Raises the <see cref="ICommand.CanExecuteChanged"/> event.
        /// </summary>
        void RaiseCanExecuteChanged();
    }
}
