using Krola.Core.Data.Interfaces;
using Krola.Domain.TimeTracking;
using Krola.TimeTracking.Api.Dto.Session;
using Krola.TimeTracking.Api.Interfaces;
using Krola.TimeTracking.Api.Mappings.Session;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Krola.TimeTracking.Api.Services
{
    public class SessionService : ISessionService
    {
        private readonly IRepository<Session> _repository;

        private const int HearbeatInterval = 60;

        public SessionService(IRepository<Session> repository)
        {
            _repository = repository;
        }

        public async Task End(int sessionId, Guid key)
        {
            var session = await GetSessionWithKey(sessionId, key);

            session.End = DateTime.UtcNow;

            await _repository.Save();
        }

        public async Task<IEnumerable<SessionDto>> GetSessions(GetSessionDto getSession)
        {
            var sessions = _repository.FindBy(s => s.DeviceId == getSession.DeviceId);

            if (getSession.From.HasValue)
            {
                sessions = sessions.Where(s => s.Start >= getSession.From.Value);
            }

            if (getSession.To.HasValue)
            {
                sessions = sessions.Where(s => s.End >= getSession.To.Value);
            }

            return await sessions.Select(s => SessionToSessionDto.Map(s)).ToListAsync();
        }

        public async Task Heartbeat(int sessionId, Guid key)
        {
            var session = await GetSessionWithKey(sessionId, key);

            session.Heartbeat = DateTime.UtcNow;

            await _repository.Save();
        }

        public async Task<NewSessionDto> Start(int deviceId)
        {
            var lastSession = await _repository.FindBy(s => s.DeviceId == deviceId)
                .OrderByDescending(s => s.Start)
                .FirstAsync();

            var hasValidHeartbeat = lastSession.Heartbeat.HasValue
                && (DateTime.UtcNow - lastSession.Heartbeat.Value).TotalSeconds < HearbeatInterval;

            if (hasValidHeartbeat && !lastSession.End.HasValue)
            {
                return SessionToNewSessionDto.Map(lastSession);
            }

            if (!hasValidHeartbeat && !lastSession.End.HasValue)
            {
                lastSession.End = lastSession.Heartbeat;
            }

            var startDate = DateTime.UtcNow;
            var newSession = new Session
            {
                DeviceId = deviceId,
                Key = Guid.NewGuid(),
                Start = startDate,
                Heartbeat = startDate
            };

            await _repository.Add(newSession);
            await _repository.Save();

            return SessionToNewSessionDto.Map(newSession);
        }

        private async Task<Session> GetSessionWithKey(int sessionId, Guid key)
        {
            if (key == null || key == Guid.Empty)
            {
                throw new ArgumentException();
            }

            var session = await _repository.FindBy(s => s.Id == sessionId).SingleOrDefaultAsync(); ;

            if (session == null)
            {
                throw new Exception("Wrong session id");
            }

            if (session.Key.Equals(key))
            {
                throw new Exception("Wrong session key");
            }

            return session;
        }
    }
}
