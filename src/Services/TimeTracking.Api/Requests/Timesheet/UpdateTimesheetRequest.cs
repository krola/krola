using System;

namespace Krola.TimeTracking.Api.Requests.Timesheet
{
    public class UpdateTimesheetRequest
    {
        public DateTime DateFrom { get; set; }

        public DateTime? DateTo { get; set; }

        public TimeSpan HourFrom { get; set; }

        public TimeSpan HourTo { get; set; }

        public TimeSpan Time { get; set; }
    }
}
