using System;

namespace Krola.TimeTracking.Api.Dto.Session
{
    public class GetSessionDto
    {
        public int DeviceId { get; set; }

        public DateTime? From { get; set; }

        public DateTime? To { get; set; }
    }
}
