using Krola.Data.TimeTracking;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Krola.TimeTracking.Api.Factories
{
    public class DbContextOptionsBuilderFactory
    {
        public static DbContextOptionsBuilder Create()
        {
            var connectionString = Startup.Configuration.GetConnectionString("DefaultConnection");
            var migrationsAssembly = typeof(TimeTrackingDbContext).GetTypeInfo().Assembly.GetName().Name;

            return (new DbContextOptionsBuilder()).UseSqlite(connectionString, sql => sql.MigrationsAssembly(migrationsAssembly));
        }
    }
}
