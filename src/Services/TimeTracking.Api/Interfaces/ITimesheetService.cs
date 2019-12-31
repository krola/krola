using Krola.TimeTracking.Api.Dto.Timesheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Krola.TimeTracking.Api.Interfaces
{
    public interface ITimesheetService
    {
        Task<TimesheetDto> Add(AddTimesheetDto addTimesheetDto);

        Task Delete(int timesheetId);

        Task<IEnumerable<TimesheetDto>> Get(int scheduleId, DateTime from, DateTime? to);

        Task<TimesheetDto> Update(int timesheetId, UpdateTimesheetDto newTimesheetDto);
    }
}
