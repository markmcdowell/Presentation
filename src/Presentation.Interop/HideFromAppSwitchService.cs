using System.ComponentModel.Composition;
using Presentation.Interfaces;
using Presentation.Interop.Native;

namespace Presentation.Interop
{
    [Export(typeof(IHideFromAppSwitchService))]
    public sealed class HideFromAppSwitchService : IHideFromAppSwitchService
    {
        public void HideFromAppSwitch(IWindowWithHandle windowWithHandle)
        {
            var handle = windowWithHandle.RetrieveHandle();

            var index = (int) Gwl.GWL_EXSTYLE;

            var style = UserNativeMethods.GetWindowLong(handle, index);

            style |= (int)Ws.WS_EX_TOOLWINDOW;

            UserNativeMethods.SetWindowLong(handle, index, style);
        }
    }
}