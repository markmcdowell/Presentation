using System;
using System.Windows;

namespace Presentation.Interfaces
{
    public interface IWindow
    {
        object DataContext { get; set; }

        string Title { get; set; }

        double Left { get; set; }

        double Top { get; set; }

        double Width { get; set; }

        double Height { get; set; }

        event EventHandler Activated;

        event EventHandler Closed;

        event EventHandler Deactivated;

        event EventHandler LocationChanged;

        event SizeChangedEventHandler SizeChanged;

        void Close();

        void Show();
    }
}