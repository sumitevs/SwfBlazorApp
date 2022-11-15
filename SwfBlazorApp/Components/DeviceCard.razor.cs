using Microsoft.AspNetCore.Components;
using SwfBlazorApp.Shared;

namespace SwfBlazorApp.Components
{
    public partial class DeviceCard
    {
        [Parameter]
        public DeviceInfo DeviceInfo { get; set; } = default!;
        [Parameter]
        public EventCallback<DeviceInfo> DeviceQuickViewClicked { get; set; }

        protected override void OnInitialized()
        {
            if (string.IsNullOrEmpty(DeviceInfo.DeviceName)) 
            {
                throw new ArgumentException("Device Name can't be empty");
            }
        }
    }
}
