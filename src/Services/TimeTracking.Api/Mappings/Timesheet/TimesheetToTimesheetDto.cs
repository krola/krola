using Krola.TimeTracking.Api.Dto.Timesheet;
using Krola.TimeTracking.Api.Mappings.Schedule;

namespace Krola.TimeTracking.Api.Mappings.Timesheet
{
    public static class TimesheetToTimesheetDto
    {
        public static TimesheetDto Map(Domain.TimeTracking.Timesheet timesheet) => new TimesheetDto
        {
            Id = timesheet.Id,
            DateFrom = timesheet.DateFrom,
            DateTo = timesheet.DateTo,
            HourFrom = timesheet.HourFrom,
            HourTo = timesheet.HourTo,
            Time = timesheet.Time,
            Schedule = ScheduleToScheduleDto.Map(timesheet.Schedule)
        };
    }
}
