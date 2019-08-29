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
        public async Task<JsonResult> Add([FromBody]string name)
        {
            var newDevice = await _deviceService.Add(name);

            return new JsonResult(newDevice);
        }
    }
}