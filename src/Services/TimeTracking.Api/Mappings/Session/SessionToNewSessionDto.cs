using Krola.TimeTracking.Api.Dto.Session;

namespace Krola.TimeTracking.Api.Mappings.Session
{
    public class SessionToNewSessionDto
    {
        public static NewSessionDto Map(Domain.TimeTracking.Session session) => new NewSessionDto
        {
            Id = session.Id,
            Key = session.Key
        };
    }
}
