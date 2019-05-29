using Krola.TimeTracking.Api.Interfaces.Devices;
using Krola.TimeTracking.Api.Requests.Device;
using Krola.TimeTracking.Api.Responses.Device;
using Krola.Web.Api.Core.Interfaces;
using Krola.Web.Api.Core.Interfaces.Gateways.Repositories;
using System;
using System.Threading.Tasks;

namespace Krola.TimeTracking.Api.Handlers.Device
{
    public class GetAllDevicesUseCase : IGetAllDevicesUseCase
    {
        private readonly IRepository<Domain.TimeTracking.Device> _repository;

        public GetAllDevicesUseCase(IRepository<Domain.TimeTracking.Device> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(GetAllDevicesRequest message, IOutputPort<GetAllDevicesResponse> outputPort)
        {
            var allDevices = await _repository.ListAll();

            outputPort.Handle(new GetAllDevicesResponse { Devices = allDevices });

            return true;
        }
    }
}
