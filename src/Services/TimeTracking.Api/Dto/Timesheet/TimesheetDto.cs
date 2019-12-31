using Krola.TimeTracking.Api.Dto.Schedule;
using System;

namespace Krola.TimeTracking.Api.Dto.Timesheet
{
    public class TimesheetDto
    {
        public int Id { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime? DateTo { get; set; }

        public TimeSpan HourFrom { get; set; }

        public TimeSpan HourTo { get; set; }

        public TimeSpan Time { get; set; }

        public ScheduleDto Schedule { get; set; }
    }
}
