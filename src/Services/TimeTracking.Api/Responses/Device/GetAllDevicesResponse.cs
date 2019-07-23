using System.Collections.Generic;

namespace Krola.TimeTracking.Api.Responses.Device
{
    public class GetAllDevicesResponse
    {
        public IEnumerable<Domain.TimeTracking.Device> Devices { get; set; }
    }
}
