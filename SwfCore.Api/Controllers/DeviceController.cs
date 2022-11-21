using SwfCore.Api.Models;
using SwfBlazorApp.Shared;
using Microsoft.AspNetCore.Mvc;

namespace SwfCore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : Controller
    {
        private readonly IDeviceRepository _deviceRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DeviceController(IDeviceRepository deviceRepository, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor)
        {
            _deviceRepository = deviceRepository;
            _webHostEnvironment = webHostEnvironment;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public IActionResult GetAllDevices()
        {
            var devices = _deviceRepository.GetAllDevices();
            if (devices.Any())
            {
                return Ok(devices);
            }
            return NoContent();
        }

        [HttpGet("{deviceName}")]
        public IActionResult GetDeviceByName(string deviceName)
        {
            var device = _deviceRepository.GetDeviceByName(deviceName);
            if (device is not null)
            {
                return Ok(device);
            }
            return NoContent();
        }

        [HttpPost]
        public IActionResult CreateDevice([FromBody] DeviceInfo deviceInfo)
        {
            if (deviceInfo == null)
                return BadRequest();

            if (deviceInfo.DeviceName == string.Empty || deviceInfo.DeviceType == string.Empty)
            {
                ModelState.AddModelError("Name/Type", "The name or type shouldn't be empty");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //handle image upload
            string currentUrl = _httpContextAccessor.HttpContext.Request.Host.Value;
            var path = $"{_webHostEnvironment.WebRootPath}\\uploads\\{deviceInfo.ImageName}";
            var fileStream = System.IO.File.Create(path);
            fileStream.Write(deviceInfo.ImageContent, 0, deviceInfo.ImageContent.Length);
            fileStream.Close();

            deviceInfo.ImageName = $"https://{currentUrl}/uploads/{deviceInfo.ImageName}";

            var createdDevice = _deviceRepository.AddDevice(deviceInfo);

            return Created("device", createdDevice);
        }

        [HttpPut]
        public IActionResult UpdateDevice([FromBody] DeviceInfo deviceInfo)
        {
            if (deviceInfo == null)
                return BadRequest();

            if (deviceInfo.DeviceName == string.Empty || deviceInfo.DeviceType == string.Empty)
            {
                ModelState.AddModelError("Name/Type", "The name or type shouldn't be empty");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var deviceToUpdate = _deviceRepository.GetDeviceByName(deviceInfo.DeviceName);

            if (deviceToUpdate == null)
                return NotFound();

            _deviceRepository.UpdateDevice(deviceInfo);

            return NoContent(); //success
        }

        [HttpDelete("{deviceName}")]
        public IActionResult DeleteDevice(string deviceName)
        {
            if (deviceName == string.Empty)
                return BadRequest();

            var employeeToDelete = _deviceRepository.GetDeviceByName(deviceName);
            if (employeeToDelete == null)
                return NotFound();

            _deviceRepository.DeleteDevice(deviceName);

            return NoContent();//success
        }
    }
}
