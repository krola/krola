using System;

namespace Krola.TimeTracking.Api.Dto.Session
{
    public class SessionDto
    {
        public int Id { get; set; }

        public DateTime Start { get; set; }

        public DateTime? End { get; set; }
    }
}
