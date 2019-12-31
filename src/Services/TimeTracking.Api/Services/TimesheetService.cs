using Krola.Core.Data.Interfaces;
using Krola.Domain.TimeTracking;
using Krola.TimeTracking.Api.Dto.Timesheet;
using Krola.TimeTracking.Api.Interfaces;
using Krola.TimeTracking.Api.Mappings.Timesheet;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Krola.TimeTracking.Api.Services
{
    public class TimesheetService : ITimesheetService
    {
        private readonly IRepository<Timesheet> _repository;

        public TimesheetService(IRepository<Timesheet> repository)
        {
            _repository = repository;
        }

        public async Task<TimesheetDto> Add(AddTimesheetDto addTimesheetDto)
        {
            var newTimesheet = new Timesheet
            {
                ScheduleId = addTimesheetDto.ScheduleId,
                DateFrom = addTimesheetDto.DateFrom,
                DateTo = addTimesheetDto.DateTo,
                HourFrom = addTimesheetDto.HourFrom,
                HourTo = addTimesheetDto.HourTo,
                Time = addTimesheetDto.Time
            };

            await _repository.Add(newTimesheet);
            await _repository.Save();

            return TimesheetToTimesheetDto.Map(newTimesheet);
        }

        public async Task Delete(int timesheetId)
        {
            var timesheet = _repository.FindBy(s => s.Id == timesheetId).SingleOrDefault();

            if (timesheet == null)
            {
                throw new KeyNotFoundException();
            }

            _repository.Delete(timesheet);

            await _repository.Save();
        }

        public async Task<IEnumerable<TimesheetDto>> Get(int scheduleId, DateTime from, DateTime? to)
        {
            var timesheetQuery = _repository.FindBy(t => t.ScheduleId == scheduleId && t.DateFrom >= from);

            if (to.HasValue)
            {
                timesheetQuery = timesheetQuery.Where(t => t.DateTo <= to);
            }

            return await timesheetQuery
                .Select(t => TimesheetToTimesheetDto.Map(t))
                .ToListAsync();
        }

        public async Task<TimesheetDto> Update(int timesheetId, UpdateTimesheetDto newTimesheetDto)
        {
            var timesheet = _repository.FindBy(s => s.Id == timesheetId).SingleOrDefault();

            if (timesheet == null)
            {
                throw new KeyNotFoundException();
            }

            timesheet.DateFrom = newTimesheetDto.DateFrom;
            timesheet.DateTo = newTimesheetDto.DateTo;
            timesheet.HourFrom = newTimesheetDto.HourFrom;
            timesheet.HourTo = newTimesheetDto.HourTo;
            timesheet.Time = newTimesheetDto.Time;

            await _repository.Save();

            return TimesheetToTimesheetDto.Map(timesheet);
        }

        //ToDo add timesheet overlapping logic
    }
}
