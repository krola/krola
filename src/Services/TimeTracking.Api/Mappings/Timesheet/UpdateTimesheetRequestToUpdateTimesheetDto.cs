using Krola.TimeTracking.Api.Dto.Timesheet;
using Krola.TimeTracking.Api.Requests.Timesheet;

namespace Krola.TimeTracking.Api.Mappings.Timesheet
{
    public static class UpdateTimesheetRequestToUpdateTimesheetDto
    {
        public static UpdateTimesheetDto Map(UpdateTimesheetRequest updateTimesheetRequest) => new UpdateTimesheetDto
        {
            DateFrom = updateTimesheetRequest.DateFrom,
            DateTo = updateTimesheetRequest.DateTo,
            HourFrom = updateTimesheetRequest.HourFrom,
            HourTo = updateTimesheetRequest.HourTo,
            Time = updateTimesheetRequest.Time,
        };
    }
}
