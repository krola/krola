using Krola.Core.Data;
using Krola.Data.TimeTracking;
using Krola.Domain.Shared;

namespace Krola.TimeTracking.Api
{
    public class TimeTrackingRepository<TEntity> : Repository<TimeTrackingDbContext, TEntity, TimeTrackingDbContextFactory>
        where TEntity : BaseEntity
    {
        public TimeTrackingRepository(TimeTrackingDbContextFactory dbContextFactory) : base(dbContextFactory)
        {
        }
    }
}
