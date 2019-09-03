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

        [HttpPut("{id}")]
        public async Task<OkResult> Update(int id, [FromBody]DeviceRequest deviceRequest)
        {
            await _deviceService.Update(id, deviceRequest.Name);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<OkResult> Delete(int id)
        {
            await _deviceService.Delete(id);

            return Ok();
        }
    }
}