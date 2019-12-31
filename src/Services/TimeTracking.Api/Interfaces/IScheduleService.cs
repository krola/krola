using Krola.Domain.TimeTracking;
using Krola.TimeTracking.Api.Dto.Schedule;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Krola.TimeTracking.Api.Interfaces
{
    public interface IScheduleService
    {
        Task<ScheduleDto> Add(AddScheduleDto addScheduleDto);

        Task Delete(int scheduleId);

        Task<IEnumerable<ScheduleDto>> GetAll(int deviceId);

        Task<ScheduleDto> Update(int scheduleId, UpdateScheduleDto newScheduleDto);
    }
}
