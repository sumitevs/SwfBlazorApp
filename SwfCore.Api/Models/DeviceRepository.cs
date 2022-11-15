using SwfBlazorApp.Shared;

namespace SwfCore.Api.Models
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly AppDbContext _appDbContext;
        private Random random = new Random();

        public DeviceRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<DeviceInfo> GetAllDevices()
        {
            return _appDbContext.Devices;
        }

        public DeviceInfo GetDeviceByName(string deviceName)
        {
            return _appDbContext.Devices.FirstOrDefault(c => c.DeviceName == deviceName);
        }

        public DeviceInfo AddDevice(DeviceInfo deviceInfo)
        {
            var addedEntity = _appDbContext.Devices.Add(deviceInfo);
            _appDbContext.SaveChanges();
            return addedEntity.Entity;
        }

        public DeviceInfo UpdateDevice(DeviceInfo deviceInfo)
        {
            var foundDevice = _appDbContext.Devices.FirstOrDefault(e => e.DeviceName == deviceInfo.DeviceName);

            if (foundDevice != null)
            {
                foundDevice.DeviceType = deviceInfo.DeviceType;
                foundDevice.IsConnected = deviceInfo.IsConnected;
               
                //foundEmployee.ImageContent = employee.ImageContent;
                //foundEmployee.ImageName = employee.ImageName;

                _appDbContext.SaveChanges();

                return foundDevice;
            }

            return null;
        }

        public void DeleteDevice(string deviceName)
        {
            var foundDevice = _appDbContext.Devices.FirstOrDefault(e => e.DeviceName == deviceName);
            if (foundDevice == null) return;

            _appDbContext.Devices.Remove(foundDevice);
            _appDbContext.SaveChanges();
        }
    }
}
