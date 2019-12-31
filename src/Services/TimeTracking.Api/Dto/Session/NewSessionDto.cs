using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Krola.TimeTracking.Api.Dto.Session
{
    public class NewSessionDto
    {
        public int Id { get; set; }

        public Guid Key { get; set; }
    }
}
