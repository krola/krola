using Krola.TimeTracking.Api.Dto.Schedule;
using Krola.TimeTracking.Api.Requests.Schedule;

namespace Krola.TimeTracking.Api.Mappings.Schedule
{
    public static class UpdateScheduleRequestToUpdateScheduleDto
    {
        public static UpdateScheduleDto Map(UpdateScheduleRequest updateScheduleRequest)
        {
            return new UpdateScheduleDto
            {
                AllowWithNoTimesheet = updateScheduleRequest.AllowWithNoTimesheet,
                Enabled = updateScheduleRequest.Enabled,
                Name = updateScheduleRequest.Name
            };
        }
    }
}
