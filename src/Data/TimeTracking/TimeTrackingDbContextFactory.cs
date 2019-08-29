using Krola.Core.Data;
using Microsoft.EntityFrameworkCore;

namespace Krola.Data.TimeTracking
{
    public class TimeTrackingDbContextFactory : DesignTimeDbContextFactoryBase<TimeTrackingDbContext>
    {
        protected override TimeTrackingDbContext CreateNewInstance(DbContextOptions<TimeTrackingDbContext> options)
        {
            return new TimeTrackingDbContext(options);
        }
    }
}
