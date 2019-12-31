using Krola.TimeTracking.Api.Dto.Session;

namespace Krola.TimeTracking.Api.Mappings.Session
{
    public static class SessionToSessionDto
    {
        public static SessionDto Map(Domain.TimeTracking.Session session) => new SessionDto
        {
            Id = session.Id,
            Start = session.Start,
            End = session.End,
        };
    }
}
