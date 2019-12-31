using Krola.Core.Data.Interfaces;
using Krola.Domain.TimeTracking;
using Krola.TimeTracking.Api.Dto.Device;
using Krola.TimeTracking.Api.Dto.Schedule;
using Krola.TimeTracking.Api.Interfaces;
using Krola.TimeTracking.Api.Mappings.Schedule;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Krola.TimeTracking.Api.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly IRepository<Schedule> _repository;

        public ScheduleService(IRepository<Schedule> repository)
        {
            _repository = repository;
        }

        public async Task<ScheduleDto> Add(AddScheduleDto addScheduleDto)
        {
            var newSchedule = new Schedule
            {
                Name = addScheduleDto.Name,
                DeviceId = addScheduleDto.DeviceId
            };

            await _repository.Add(newSchedule);
            await _repository.Save();

            return new ScheduleDto
            {
                Name = newSchedule.Name,
                AllowWithNoTimesheet = newSchedule.AllowWithNoTimesheet,
                Enabled = newSchedule.Enabled,
                Device = new DeviceDto
                {
                    Id = newSchedule.Device.Id,
                    Name = newSchedule.Device.Name
                }
            };
        }

        public async Task Delete(int scheduleId)
        {
            var schedule = _repository.FindBy(s => s.Id == scheduleId).SingleOrDefault();

            if (schedule == null)
            {
                throw new KeyNotFoundException();
            }

            _repository.Delete(schedule);

            await _repository.Save();
        }

        public async Task<IEnumerable<ScheduleDto>> GetAll(int deviceId)
        {
            return await _repository.GetAll()
                .Where(s => s.DeviceId == deviceId)
                .Select(s => ScheduleToScheduleDto.Map(s))
                .ToListAsync();
        }

        public async Task<ScheduleDto> Update(int scheduleId, UpdateScheduleDto newScheduleDto)
        {
            var schedule = _repository
                .FindBy(s => s.Id == scheduleId)
                .SingleOrDefault();

            if (schedule == null)
            {
                throw new KeyNotFoundException();
            }

            if (newScheduleDto.Enabled)
            {
                await _repository.FindBy(s => s.DeviceId == schedule.DeviceId)
                    .ForEachAsync(s => s.Enabled = false);
            }

            schedule.Name = newScheduleDto.Name;
            schedule.Enabled = newScheduleDto.Enabled;
            schedule.AllowWithNoTimesheet = newScheduleDto.AllowWithNoTimesheet;

            await _repository.Save();

            return ScheduleToScheduleDto.Map(schedule);
        }
    }
}
