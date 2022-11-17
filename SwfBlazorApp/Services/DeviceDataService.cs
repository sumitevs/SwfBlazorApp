using Blazored.LocalStorage;
using SwfBlazorApp.Helper;
using SwfBlazorApp.Shared;
using System.Net.Http.Json;
using System.Text.Json;

namespace SwfBlazorApp.Services
{
    public class DeviceDataService : IDeviceDataService
    {
        private readonly HttpClient httpClient;
        private readonly ILocalStorageService localStorageService;

        public DeviceDataService(HttpClient httpClient, ILocalStorageService localStorageService)
        {
            this.httpClient = httpClient;
            this.localStorageService = localStorageService;
        }
        public async Task<DeviceInfo?> AddDeviceInfo(DeviceInfo deviceInfo)
        {
            var jsonContent = JsonContent.Create(deviceInfo);
            var response = await httpClient.PostAsync("api/Device", jsonContent);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<DeviceInfo>();
        }

        public Task DeleteDeviceInfo(string deviceName)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<DeviceInfo>> GetAllDevices(bool refreshRequired = false)
        {
            if (!refreshRequired)
            {
                bool deviceExpirationExists = await localStorageService.ContainKeyAsync(LocalStorageConstants.DeviceListExpirationKey);
                if (deviceExpirationExists) 
                {
                    DateTime expirationDate = await localStorageService.GetItemAsync<DateTime>(LocalStorageConstants.DeviceListExpirationKey);
                    if(expirationDate > DateTime.Now) 
                    {
                        if (await localStorageService.ContainKeyAsync(LocalStorageConstants.DeviceListKey))
                        {
                            return await localStorageService.GetItemAsync<List<DeviceInfo>>(LocalStorageConstants.DeviceListKey);
                        }
                    }
                }
            }
            // othereise refresh the list, set locally expry as 1min

            var list = await JsonSerializer.DeserializeAsync<IEnumerable<DeviceInfo>>
                (await httpClient.GetStreamAsync($"api/device"), new
                JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            await localStorageService.SetItemAsync(LocalStorageConstants.DeviceListKey, list);
            await localStorageService.SetItemAsync(LocalStorageConstants.DeviceListExpirationKey, DateTime.Now.AddMinutes(1));
            return list;
        }

        public async Task<DeviceInfo> GetDeviceDetails(string deviceName)
        {
            return await JsonSerializer.DeserializeAsync<DeviceInfo>
                (await httpClient.GetStreamAsync($"api/device/{deviceName}"), new
                JsonSerializerOptions()
                { PropertyNameCaseInsensitive = true });
        }

        public Task UpdateDevice(DeviceInfo deviceInfo)
        {
            throw new NotImplementedException();
        }
    }
}
