using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Krola.Core.Data.Interfaces;
using Krola.Domain.TimeTracking;
using Krola.TimeTracking.Api.Dto;
using Krola.TimeTracking.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Krola.TimeTracking.Api.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly IRepository<Device> _repository;

        public DeviceService(IRepository<Device> repository)
        {
            _repository = repository;
        }

        public async Task<DeviceDto> Add(string name)
        {
            var newDevice = new Device
            {
                Name = name
            };

            await _repository.Add(newDevice);
            await _repository.Save();

            return new DeviceDto
            {
                Id = newDevice.Id,
                Name = newDevice.Name,
            };
        }

        public async Task<IEnumerable<DeviceDto>> GetAll()
        {
            return await _repository.GetAll()
                .Select(d => new DeviceDto
                {
                    Id = d.Id,
                    Name = d.Name
                })
                .ToListAsync();
        }

        public void Remove(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(int id, string NewName)
        {
            throw new System.NotImplementedException();
        }
    }
}
