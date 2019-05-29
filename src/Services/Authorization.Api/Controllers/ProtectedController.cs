using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Krola.Authorization.Api.Controllers
{
    [Authorize(Policy = "ApiUser")]
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        // GET api/test/ping
        [HttpGet]
        public IActionResult Ping()
        {
            return new OkObjectResult(new { result = true });
        }
    }
}
