using Krola.TimeTracking.Api.Dto;
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

        void Remove(int id);

        void Update(int id, string newName);
    }
}
