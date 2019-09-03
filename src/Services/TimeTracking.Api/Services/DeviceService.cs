using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Krola.Core.Data.Interfaces;
using Krola.Core.Infrastructure.Interfaces;
using Krola.Domain.TimeTracking;
using Krola.TimeTracking.Api.Dto;
using Krola.TimeTracking.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Krola.TimeTracking.Api.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly IRepository<Device> _repository;
        private readonly IHttpContextUserProvider _httpContextUserProvider;

        public DeviceService(IRepository<Device> repository, IHttpContextUserProvider httpContextUserProvider)
        {
            _repository = repository;
            _httpContextUserProvider = httpContextUserProvider;
        }

        public async Task<DeviceDto> Add(string name)
        {
            var userId = await _httpContextUserProvider.GetUserId();
            var newDevice = new Device
            {
                Name = name,
                UserId = userId
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
            var userId = await _httpContextUserProvider.GetUserId();
            return await _repository.GetAll()
                .Where(d => d.UserId == userId)
                .Select(d => new DeviceDto
                {
                    Id = d.Id,
                    Name = d.Name
                })
                .ToListAsync();
        }

        public async Task Delete(int id)
        {
            var device = _repository.FindBy(d => d.Id == id).SingleOrDefault();

            if (device == null)
            {
                throw new KeyNotFoundException();
            }

            _repository.Delete(device);
            await _repository.Save();
        }

        public async Task Update(int id, string newName)
        {
            var device = _repository.FindBy(d => d.Id == id).SingleOrDefault();

            if (device == null)
            {
                throw new KeyNotFoundException();
            }

            device.Name = newName;

            await _repository.Save();
        }
    }
}
