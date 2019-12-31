using Krola.TimeTracking.Api.Dto.Device;
using Krola.TimeTracking.Api.Dto.Schedule;

namespace Krola.TimeTracking.Api.Mappings.Schedule
{
    public static class ScheduleToScheduleDto
    {
        public static ScheduleDto Map(Domain.TimeTracking.Schedule schedule) => new ScheduleDto
        {
            Id = schedule.Id,
            AllowWithNoTimesheet = schedule.AllowWithNoTimesheet,
            Name = schedule.Name,
            Enabled = schedule.Enabled,
            Device = new DeviceDto
            {
                Id = schedule.Device.Id,
                Name = schedule.Device.Name
            }
        };
    }
}
