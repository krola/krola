using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Krola.TimeTracking.Api.Requests.Session
{
    public class EndSessionRequest
    {
        public int SessionId { get; set; }

        public Guid Key { get; set; }
    }
}
