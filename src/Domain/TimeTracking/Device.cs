using Krola.Domain.Shared;
using System.Collections.Generic;

namespace Krola.Domain.TimeTracking
{
    public class Device : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<Schedule> Schedules { get; set; }

        public ICollection<Session> Sessions { get; set; }
    }
}
