using System.Threading.Tasks;
using Krola.TimeTracking.Api.Requests.Device;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Krola.TimeTracking.Api.Controllers
{
    [Route("api/[controller]")]
    //[Authorize(Policy = "ApiUser")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        public ActionResult Get()
        {
            return Ok();
        }
    }
}