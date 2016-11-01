using System.Windows.Input;

namespace Presentation.Interfaces
{
    /// <summary>
    /// Defines a command that can raise the <see cref="ICommand.CanExecuteChanged"/> event.
    /// </summary>
    public interface IRaiseableCommand : ICommand
    {
        /// <summary>
        /// Raises the <see cref="ICommand.CanExecuteChanged"/> event.
        /// </summary>
        void RaiseCanExecuteChanged();
    }
}
