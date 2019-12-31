using System.Threading.Tasks;
using Krola.TimeTracking.Api.Interfaces;
using Krola.TimeTracking.Api.Requests.Device;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Krola.TimeTracking.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize()]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private readonly IDeviceService _deviceService;

        public DeviceController(IDeviceService deviceService)
        {
            _deviceService = deviceService;
        }

        [HttpGet]
        public async Task<JsonResult> GetAll()
        {
            var devices = await _deviceService.GetAll();

            return new JsonResult(devices);
        }

        [HttpPost]
        public async Task<JsonResult> Add([FromBody]DeviceRequest deviceRequest)
        {
            var newDevice = await _deviceService.Add(deviceRequest.Name);

            return new JsonResult(newDevice);
        }

        [HttpPut("{deviceId}")]
        public async Task<OkResult> Update(int deviceId, [FromBody]DeviceRequest deviceRequest)
        {
            await _deviceService.Update(deviceId, deviceRequest.Name);

            return Ok();
        }

        [HttpDelete("{deviceId}")]
        public async Task<OkResult> Delete(int deviceId)
        {
            await _deviceService.Delete(deviceId);

            return Ok();
        }
    }
}