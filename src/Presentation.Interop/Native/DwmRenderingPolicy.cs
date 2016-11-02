using System;

namespace Presentation.Interop.Native
{
    [Flags]
    internal enum DwmRenderingPolicy
    {
        UseWindowStyle,        
        Disabled,
        Enabled,
        Last
    }
}