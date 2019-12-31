using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Krola.TimeTracking.Api.Requests.Timesheet
{
    public class AddTimesheetRequest
    {
        public DateTime DateFrom { get; set; }

        public DateTime? DateTo { get; set; }

        public TimeSpan HourFrom { get; set; }

        public TimeSpan HourTo { get; set; }

        public TimeSpan Time { get; set; }

        public int ScheduleId { get; set; }
    }
}
