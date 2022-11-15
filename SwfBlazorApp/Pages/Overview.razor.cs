using SwfBlazorApp.Models;
using SwfBlazorApp.Shared;

namespace SwfBlazorApp.Pages
{
    public partial class Overview
    {
        public List<DeviceInfo>? DeviceInfoList { get; set; } = default!;
        private DeviceInfo? _selectDeviceInfo;
        private string Title = "Device Overview";
        protected override void OnInitialized()
        {
            DeviceInfoList = MockDataService.DeviceInfoList;
        }

        public void ShowQuickViewPopup(DeviceInfo selectDeviceInfo)
        {
            _selectDeviceInfo = selectDeviceInfo;
        }
    }
}
