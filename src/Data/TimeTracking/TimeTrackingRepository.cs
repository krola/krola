using Krola.Core.Data;
using Krola.Domain.Shared;

namespace Krola.Data.TimeTracking
{
    public class TimeTrackingRepository<TEntity> : Repository<TimeTrackingDbContext, TEntity, TimeTrackingDbContextFactory>
        where TEntity : BaseEntity
    {
        public TimeTrackingRepository(TimeTrackingDbContextFactory dbContextFactory) : base(dbContextFactory)
        {
        }
    }
}
