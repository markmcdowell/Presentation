using System.ComponentModel.Composition;
using Presentation.Interfaces;
using Presentation.Interop.Native;

namespace Presentation.Interop
{
    [Export(typeof(IHideFromPeekService))]
    public sealed class HideFromPeekService : IHideFromPeekService
    {
        public void HideFromPeek(IWindowWithHandle window)
        {            
            var handle = window.Handle;

            var attrValue = (int)DwmRenderingPolicy.Enabled;

            DwmNativeMethods.DwmSetWindowAttribute(handle, DwmWindowAttribute.ExcludedFromPeek, ref attrValue, sizeof(int));

            DwmNativeMethods.DwmSetWindowAttribute(handle, DwmWindowAttribute.DisallowPeek, ref attrValue, sizeof(int));
        }
    }
}