using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Reflection;

namespace Krola.Core.Data
{
    public class DbContextOptionsBuilderFactory
    {
        public const string ConnectionStringName = "DefaultConnection";
        public static void SetupContextOptionsBuilder(DbContextOptionsBuilder contextOptionsBuilder, Assembly migrationsAssembly,
            string connectionStringName = ConnectionStringName)
        {
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            //var basePath = AppContext.BaseDirectory;
            var basePath = Environment.CurrentDirectory;

            Console.WriteLine("DesignTimeDbContextFactory.Create(string): Base path string: {0}", basePath);

            var builder = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{environmentName}.json", true)
                .AddEnvironmentVariables();

            var config = builder.Build();
            var connectionString = config.GetConnectionString(connectionStringName);

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException(
                    $"Could not find a connection string named '{ConnectionStringName}'.");
            }

            Console.WriteLine("DesignTimeDbContextFactory.Create(string): Connection string: {0}", connectionString);

            contextOptionsBuilder.UseNpgsql(connectionString, m =>
            {
                m.MigrationsAssembly(migrationsAssembly.FullName);
                m.SetPostgresVersion(new Version(9, 6));
        });
        }

        public static void SetupContextOptionsBuilder<TContext>(DbContextOptionsBuilder contextOptionsBuilder) where TContext : DbContext
        {
            SetupContextOptionsBuilder(contextOptionsBuilder, typeof(TContext).Assembly);
        }

        public static DbContextOptionsBuilder<TContext> Create<TContext>() where TContext : DbContext
        {
            var contextOptionsBuilder = new DbContextOptionsBuilder<TContext>();

            SetupContextOptionsBuilder(contextOptionsBuilder, typeof(TContext).Assembly);

            return contextOptionsBuilder;
        }
    }
}
