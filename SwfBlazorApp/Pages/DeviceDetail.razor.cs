using Microsoft.AspNetCore.Components;
using SwfBlazorApp.Models;
using SwfBlazorApp.Shared;

namespace SwfBlazorApp.Pages
{
    public partial class DeviceDetail
    {
        [Parameter]
        public string DeviceName { get; set; }
        public DeviceInfo? DeviceInfo { get; set; } = new DeviceInfo();

        protected override Task OnInitializedAsync()
        {
            DeviceInfo = MockDataService.DeviceInfoList.FirstOrDefault(d => d.DeviceName == DeviceName);
            return base.OnInitializedAsync();
        }
    }
}
