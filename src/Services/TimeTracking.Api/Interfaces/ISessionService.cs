using Krola.TimeTracking.Api.Dto.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Krola.TimeTracking.Api.Interfaces
{
    public interface ISessionService
    {
        Task<IEnumerable<SessionDto>> GetSessions(GetSessionDto getSession);

        Task<NewSessionDto> Start(int deviceId);

        Task End(int sessionId, Guid key);

        Task Heartbeat(int sessionId, Guid key);
    }
}
