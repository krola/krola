using Krola.TimeTracking.Api.Interfaces;
using Krola.TimeTracking.Api.Requests.Session;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Krola.TimeTracking.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize()]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly ISessionService _sessionService;

        public SessionController(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }

        [HttpPost(nameof(Start))]
        public async Task<JsonResult> Start([FromBody]StartSessionRequest startSessionRequest)
        {
            var newSession = await _sessionService.Start(startSessionRequest.DeviceId);

            return new JsonResult(newSession);
        }

        [HttpPost(nameof(End))]
        public async Task<OkResult> End([FromBody]EndSessionRequest endSessionRequest)
        {
            await _sessionService.End(endSessionRequest.SessionId, endSessionRequest.Key);

            return Ok();
        }

        [HttpPost(nameof(Heartbeat))]
        public async Task<OkResult> Heartbeat([FromBody]EndSessionRequest endSessionRequest)
        {
            await _sessionService.Heartbeat(endSessionRequest.SessionId, endSessionRequest.Key);

            return Ok();
        }
    }
}