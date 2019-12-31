using System.Threading.Tasks;
using Krola.TimeTracking.Api.Dto.Schedule;
using Krola.TimeTracking.Api.Interfaces;
using Krola.TimeTracking.Api.Mappings.Schedule;
using Krola.TimeTracking.Api.Requests.Schedule;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Krola.TimeTracking.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize()]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleService _scheduleService;

        public ScheduleController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        [HttpPost]
        public async Task<JsonResult> Add([FromBody]AddScheduleRequest addScheduleRequest)
        {
            var newSchedule = await _scheduleService.Add(new AddScheduleDto { 
                DeviceId = addScheduleRequest.DeviceId,
                Name = addScheduleRequest.Name
            });

            return new JsonResult(newSchedule);
        }

        [HttpGet]
        public async Task<JsonResult> GetAll([FromQuery]int deviceId)
        {
            var schedules = await _scheduleService.GetAll(deviceId);

            return new JsonResult(schedules);
        }

        [HttpPut("{scheduleId}")]
        public async Task<OkResult> Update([FromQuery]int scheduleId, [FromBody]UpdateScheduleRequest updateScheduleRequest)
        {
            await _scheduleService.Update(scheduleId, UpdateScheduleRequestToUpdateScheduleDto.Map(updateScheduleRequest));

            return Ok();
        }

        [HttpDelete("{scheduleId}")]
        public async Task<OkResult> Delete(int scheduleId)
        {
            await _scheduleService.Delete(scheduleId);

            return Ok();
        }
    }
}