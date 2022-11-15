using Microsoft.AspNetCore.Components;
using SwfBlazorApp.Shared;

namespace SwfBlazorApp.Components
{
    public partial class QuickViewPopup
    {
        [Parameter]
        public DeviceInfo? DeviceInfo { get; set; }
        private DeviceInfo? _deviceInfo;

        protected override void OnParametersSet()
        {
            _deviceInfo = DeviceInfo;
        }
        public void Close()
        {
            _deviceInfo = null;
        }
    }
}
