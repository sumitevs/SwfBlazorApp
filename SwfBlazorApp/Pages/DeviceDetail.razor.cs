using Microsoft.AspNetCore.Components;
using SwfBlazorApp.Models;
using SwfBlazorApp.Services;
using SwfBlazorApp.Shared;

namespace SwfBlazorApp.Pages
{
    public partial class DeviceDetail
    {
        [Inject]
        public IDeviceDataService? DeviceDataService { get; set; }
        [Parameter]
        public string DeviceName { get; set; }
        public DeviceInfo? DeviceInfo { get; set; } = new DeviceInfo();

        protected async override Task OnInitializedAsync()
        {
            DeviceInfo = await DeviceDataService.GetDeviceDetails(DeviceName);
        }
    }
}
