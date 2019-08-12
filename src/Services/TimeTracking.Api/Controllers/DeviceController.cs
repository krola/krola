using System.Threading.Tasks;
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
        [HttpGet]
        public ActionResult Get()
        {
            return Ok();
        }
    }
}