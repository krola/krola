using Krola.Domain.Shared;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Krola.Domain.TimeTracking
{
    public class Timesheet : BaseEntity
    {

        public DateTime DateFrom { get; set; }
        public DateTime? DateTo { get; set; }

        public TimeSpan HourFrom { get; set; }
        public TimeSpan HourTo { get; set; }
        public TimeSpan Time { get; set; }

        public DateTime CreateTime { get; set; }

        [ForeignKey(nameof(Schedule))]
        public int ScheduleId { get; set; }
        public virtual Schedule Schedule { get; set; }
    }
}
