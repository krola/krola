using System;
using System.Threading.Tasks;
using Krola.TimeTracking.Api.Interfaces;
using Krola.TimeTracking.Api.Mappings.Timesheet;
using Krola.TimeTracking.Api.Requests.Timesheet;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Krola.TimeTracking.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize()]
    [ApiController]
    public class TimesheetController : ControllerBase
    {
        private readonly ITimesheetService _timesheetService;

        public TimesheetController(ITimesheetService timesheetService)
        {
            _timesheetService = timesheetService;
        }

        [HttpPost]
        public async Task<JsonResult> Add([FromBody]AddTimesheetRequest addTimesheetRequest)
        {
            var newTimesheet = await _timesheetService
                .Add(AddTimesheetRequestToAddTimesheetDto.Map(addTimesheetRequest));

            return new JsonResult(newTimesheet);
        }

        [HttpGet]
        public async Task<JsonResult> Get([FromQuery]int scheduleId, [FromQuery]DateTime dateFrom, [FromQuery]DateTime? dateTo)
        {
            var timesheets = await _timesheetService.Get(scheduleId, dateFrom, dateTo);

            return new JsonResult(timesheets);
        }

        [HttpPut("{timesheetId}")]
        public async Task<OkResult> Update([FromQuery]int timesheetId, [FromBody]UpdateTimesheetRequest updateTimesheetRequest)
        {
            await _timesheetService.Update(timesheetId, UpdateTimesheetRequestToUpdateTimesheetDto.Map(updateTimesheetRequest));

            return Ok();
        }

        [HttpDelete("{timesheetId}")]
        public async Task<OkResult> Delete(int timesheetId)
        {
            await _timesheetService.Delete(timesheetId);

            return Ok();
        }
    }
}