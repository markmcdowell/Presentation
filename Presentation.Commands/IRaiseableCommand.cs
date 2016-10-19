using System.Windows.Input;

namespace Presentation.Commands
{
    public interface IRaiseableCommand : ICommand
    {
        void RaiseCanExecuteChanged();
    }
}
