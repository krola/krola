using Krola.Core.Data;
using Microsoft.EntityFrameworkCore;

namespace Krola.Data.Authorization
{
    public class IdentityServerDbContextFactory : DesignTimeDbContextFactoryBase<IdentityServerDbContext>
    {
        protected override IdentityServerDbContext CreateNewInstance(DbContextOptions<IdentityServerDbContext> options)
        {
            return new IdentityServerDbContext(options);
        }
    }
}
