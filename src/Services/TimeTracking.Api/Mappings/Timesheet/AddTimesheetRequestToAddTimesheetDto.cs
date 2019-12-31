using Krola.TimeTracking.Api.Dto.Timesheet;
using Krola.TimeTracking.Api.Requests.Timesheet;

namespace Krola.TimeTracking.Api.Mappings.Timesheet
{
    public static class AddTimesheetRequestToAddTimesheetDto
    {
        public static AddTimesheetDto Map(AddTimesheetRequest addTimesheetRequest) => new AddTimesheetDto
        {
            DateFrom = addTimesheetRequest.DateFrom,
            DateTo = addTimesheetRequest.DateTo,
            HourFrom = addTimesheetRequest.HourFrom,
            HourTo = addTimesheetRequest.HourTo,
            ScheduleId = addTimesheetRequest.ScheduleId,
            Time = addTimesheetRequest.Time,
        };
    }
}
