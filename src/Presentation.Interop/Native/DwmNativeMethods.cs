using System;
using System.Runtime.InteropServices;

namespace Presentation.Interop.Native
{
    internal static class DwmNativeMethods
    {
        [DllImport("dwmapi.dll", PreserveSig = true)]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, DwmWindowAttribute attr, ref int attrValue, int attrSize);
    }
}