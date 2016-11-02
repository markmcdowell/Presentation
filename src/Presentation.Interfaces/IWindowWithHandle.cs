using System;

namespace Presentation.Interfaces
{
    public interface IWindowWithHandle : IWindow
    {
        IntPtr Handle { get; }
    }
}