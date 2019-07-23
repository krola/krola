using Krola.Domain.Shared;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Krola.Domain.TimeTracking
{
    public class Session : BaseEntity
    {
        public DateTime Star { get; set; }

        public DateTime? End { get; set; }

        [ForeignKey(nameof(Device))]
        public int DeviceId { get; set; }

        public virtual Device Device { get; set; }
    }
}
