using Krola.TimeTracking.Api.Dto.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Krola.TimeTracking.Api.Interfaces
{
    public interface IDeviceService
    {
        Task<IEnumerable<DeviceDto>> GetAll();

        Task<DeviceDto> Add(string name);

        Task Delete(int id);

        Task Update(int id, string newName);
    }
}
