using Krola.Web.Api.Core.Interfaces;
using System.Collections.Generic;

namespace Krola.TimeTracking.Api.Responses.Device
{
    public class GetAllDevicesResponse : UseCaseResponseMessage
    {
        public IEnumerable<Krola.Domain.TimeTracking.Device> Devices { get; set; }
    }
}
