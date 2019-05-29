using Krola.TimeTracking.Api.Requests.Device;
using Krola.TimeTracking.Api.Responses.Device;
using Krola.Web.Api.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Krola.TimeTracking.Api.Interfaces.Devices
{
    internal interface IGetAllDevicesUseCase : IUseCaseRequestHandler<GetAllDevicesRequest, GetAllDevicesResponse>
    {
    }
}
