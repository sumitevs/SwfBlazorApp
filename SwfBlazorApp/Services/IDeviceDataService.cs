using SwfBlazorApp.Shared;

namespace SwfBlazorApp.Services
{
    public interface IDeviceDataService
    {
        Task<IEnumerable<DeviceInfo>> GetAllDevices(bool refreshRequired);
        Task<DeviceInfo> GetDeviceDetails(string deviceName);
        Task<DeviceInfo> AddDeviceInfo(DeviceInfo deviceInfo);
        Task UpdateDevice(DeviceInfo deviceInfo);
        Task DeleteDeviceInfo(string deviceName);
    }
}
