using SwfBlazorApp.Shared;

namespace SwfBlazorApp.Models
{
    public class MockDataService
    {
        private static List<DeviceInfo> _deviceInfoList = default!; 

        public static List<DeviceInfo> DeviceInfoList 
        { 
            get 
            {
                _deviceInfoList ??= InitializeMockDeviceInfo();
                return _deviceInfoList; 
            } 
        }

        private static List<DeviceInfo> InitializeMockDeviceInfo()
        {
            return new List<DeviceInfo>() 
            { 
                new DeviceInfo{ DeviceName="device1", DeviceType="Type1", IsConnected=true },
                new DeviceInfo{ DeviceName="device2", DeviceType="Type2", IsConnected=true },
                new DeviceInfo{ DeviceName="device3", DeviceType="Type3", IsConnected=false },
                new DeviceInfo{ DeviceName=string.Empty, DeviceType="Type2", IsConnected=false },
                new DeviceInfo{ DeviceName="device5", DeviceType="Type1", IsConnected=true }
            };
        }
    }
}
