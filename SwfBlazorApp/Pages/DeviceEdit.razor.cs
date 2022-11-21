using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using SwfBlazorApp.Services;
using SwfBlazorApp.Shared;

namespace SwfBlazorApp.Pages
{
    public partial class DeviceEdit
    {
        [Inject]
        public IDeviceDataService? DeviceDataService { get; set; }
        [Parameter]
        public string DeviceName { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public DeviceInfo? DeviceInfo { get; set; } = new DeviceInfo();
        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool Saved = false;
        protected async override Task OnInitializedAsync()
        {
            if (String.IsNullOrEmpty(DeviceName))
            {
                DeviceInfo = new DeviceInfo { IsConnected=false};
            }
            else
            {
                DeviceInfo = await DeviceDataService.GetDeviceDetails(DeviceName);
            }            
        }

        protected async Task HandleValidSubmit()
        {
            Saved = false;
            if (DeviceInfo.Id == 0) // new
            {
                if (selectedFile != null)
                {
                    var file = selectedFile;
                    Stream stream = file.OpenReadStream();
                    MemoryStream memoryStream = new MemoryStream();
                    await stream.CopyToAsync(memoryStream);
                    stream.Close();
                    DeviceInfo.ImageName = file.Name;
                    DeviceInfo.ImageContent = memoryStream.ToArray();
                }
                var addDevice = await DeviceDataService.AddDeviceInfo(DeviceInfo);
                if(addDevice != null) 
                {
                    StatusClass = "alert-success";
                    Message = "New Device Added Successfully.";
                    Saved = true;
                }
                else
                {
                    StatusClass = "alert-danger";
                    Message = "Could not add New Device.";
                    Saved = false;
                }
            }
            else //editing existing
            {
                await DeviceDataService.UpdateDevice(DeviceInfo);
                StatusClass = "alert-success";
                Message = "Device updated Successfully.";
                Saved = true;
            }
        }

        private IBrowserFile selectedFile;

        private void OnInputFileChange(InputFileChangeEventArgs e)
        {
            selectedFile = e.File;
            StateHasChanged();
        }

        protected async Task HandleInvalidSubmit()
        {
            StatusClass = "alert-danger";
            Message = "Validation error.";
        }

        protected async Task DeleteDevice() 
        {
            await DeviceDataService.DeleteDeviceInfo(DeviceInfo.DeviceName);
            StatusClass = "alert-success";
            Message = "deleted successfully";
            Saved = true;
        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/overview");
        }
    }
}
