using Microsoft.AspNetCore.Components;
using SwfBlazorApp.Models;
using SwfBlazorApp.Services;
using SwfBlazorApp.Shared;

namespace SwfBlazorApp.Pages
{
    public partial class Overview
    {
        [Inject]
        public IDeviceDataService? DeviceDataService { get; set; }
        public List<DeviceInfo>? DeviceInfoList { get; set; } = default!;
        private DeviceInfo? _selectDeviceInfo;
        private string Title = "Device Overview";
        //protected override void OnInitialized()
        //{
        //    DeviceInfoList = MockDataService.DeviceInfoList;
        //}
        protected override async Task OnInitializedAsync()
        {
            DeviceInfoList = (await DeviceDataService.GetAllDevices(true)).ToList();
        }
        public void ShowQuickViewPopup(DeviceInfo selectDeviceInfo)
        {
            _selectDeviceInfo = selectDeviceInfo;
        }
    }
}
