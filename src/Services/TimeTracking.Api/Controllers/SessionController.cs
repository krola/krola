using Krola.TimeTracking.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Krola.TimeTracking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly ISessionService _sessionService;

        public SessionController(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }

        [HttpPost]
        public async Task<JsonResult> Start([FromBody]int deviceId)
        {
            var newSession = await _sessionService.Start(deviceId);

            return new JsonResult(newSession);
        }

        [HttpPost]
        public async Task<OkResult> End([FromBody]int sessionId, [FromBody]Guid key)
        {
            await _sessionService.End(sessionId, key);

            return Ok();
        }

        [HttpPost]
        public async Task<OkResult> Heartbeat([FromBody]int sessionId, [FromBody]Guid key)
        {
            await _sessionService.Heartbeat(sessionId, key);

            return Ok();
        }
    }
}