using System;

namespace Krola.TimeTracking.Api.Dto.Timesheet
{
    public class AddTimesheetDto
    {
        public DateTime DateFrom { get; set; }

        public DateTime? DateTo { get; set; }

        public TimeSpan HourFrom { get; set; }

        public TimeSpan HourTo { get; set; }

        public TimeSpan Time { get; set; }

        public int ScheduleId { get; set; }
    }
}
