using SwfBlazorApp.Models;

namespace SwfBlazorApp.Components.Widgets
{
    public partial class DeviceCountWidget
    {
        public int DeviceCounter { get; set; }

        protected override void OnInitialized()
        {
            DeviceCounter = MockDataService.DeviceInfoList.Count;
        }
    }
}
