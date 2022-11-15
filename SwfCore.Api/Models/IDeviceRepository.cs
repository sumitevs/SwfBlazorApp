using SwfBlazorApp.Shared;

namespace SwfCore.Api.Models
{
    public interface IDeviceRepository
    {
        IEnumerable<DeviceInfo> GetAllDevices();
        DeviceInfo GetDeviceByName(string deviceName);
        DeviceInfo AddDevice(DeviceInfo device);
        DeviceInfo UpdateDevice(DeviceInfo device);
        void DeleteDevice(string deviceName);
        //IEnumerable<EmployeeListModel> GetLongEmployeeList();
        //IEnumerable<EmployeeListModel> GetTakeLongEmployeeList(int request, int count);
    }
}
