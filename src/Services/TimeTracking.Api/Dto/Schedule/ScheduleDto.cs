using Krola.TimeTracking.Api.Dto.Device;

namespace Krola.TimeTracking.Api.Dto.Schedule
{
    public class ScheduleDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool AllowWithNoTimesheet { get; set; }

        public bool Enabled { get; set; }

        public DeviceDto Device { get; set; }
    }
}
