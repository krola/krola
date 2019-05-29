using Krola.Domain.Shared;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Krola.Domain.TimeTracking
{
    public class Schedule : BaseEntity
    {
        public string Name { get; set; }
        public bool AllowWithNoTimesheet { get; set; }
        public bool Enabled { get; set; }

        [ForeignKey(nameof(Device))]
        public int DeviceId { get; set; }
        public virtual Device Device { get; set; }

        public ICollection<Timesheet> Timesheets { get; set; }

    }
}
