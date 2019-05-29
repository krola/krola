using Microsoft.EntityFrameworkCore;
using Krola.Web.Api.Infrastructure.Shared;


namespace Krola.Web.Api.Infrastructure.Data
{
    public class AppDbContextFactory : DesignTimeDbContextFactoryBase<AppDbContext>
    {
        protected override AppDbContext CreateNewInstance(DbContextOptions<AppDbContext> options)
        {
            return new AppDbContext(options);
        }
    }
}
