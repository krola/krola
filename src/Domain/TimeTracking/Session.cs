using Krola.Domain.Shared;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Krola.Domain.TimeTracking
{
    public class Session : BaseEntity
    {
        public DateTime StarTime { get; set; }

        public DateTime? EndTime { get; set; }

        [ForeignKey(nameof(Device))]
        public int DeviceId { get; set; }
        public virtual Device Device { get; set; }
    }
}
