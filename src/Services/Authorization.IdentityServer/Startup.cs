using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Reflection;
using Krola.Authorization.IdentityServer.Data;

namespace Krola.Authorization.IdentityServer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var migrationsAssembly = typeof(AppIdentityDbContext).GetTypeInfo().Assembly.GetName().Name;

            services.AddDbContext<AppIdentityDbContext>(options => options.UseSqlite(Configuration.GetConnectionString("Default"), b => b.MigrationsAssembly(migrationsAssembly)));

            services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<AppIdentityDbContext>().AddDefaultTokenProviders();

            services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddConfigurationStore(options => options.ConfigureDbContext = builder => builder.UseSqlite(Configuration.GetConnectionString("Default"), b => b.MigrationsAssembly(migrationsAssembly)))
                .AddOperationalStore(options => {
                    options.ConfigureDbContext = builder => builder.UseSqlite(Configuration.GetConnectionString("Default"), b => b.MigrationsAssembly(migrationsAssembly));

                    // this enables automatic token cleanup. this is optional. 
                    options.EnableTokenCleanup = true;
                    options.TokenCleanupInterval = 30;
                })
                .AddAspNetIdentity<AppUser>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.InitializeDatabase();
            app.UseDeveloperExceptionPage();
            app.UseIdentityServer();
        }
    }
}
