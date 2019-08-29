using Krola.Core.Data;
using Krola.Core.Data.Interfaces;
using Krola.Data.TimeTracking;
using Krola.Domain.Shared;
using Krola.TimeTracking.Api.Interfaces;
using Krola.TimeTracking.Api.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System.Collections.Generic;

namespace Krola.TimeTracking.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration Configuration { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TimeTrackingDbContext>(options => DbContextOptionsBuilderFactory<TimeTrackingDbContext>.Create());

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "TimeTracking API", Version = "v1" });
                // Swagger 2.+ support
                c.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    In = "header",
                    Description = "Please insert JWT with Bearer into field",
                    Name = "Authorization",
                    Type = "apiKey"
                });

                c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
                {
                    { "Bearer", new string[] { } }
                });
            });
            services.AddSingleton(typeof(TimeTrackingDbContextFactory));
            services.AddTransient(typeof(IRepository<>), typeof(TimeTrackingRepository<>));
            services.AddTransient<IDeviceService, DeviceService>();
            services.AddMvc();
            services.AddAuthentication("Bearer")
                .AddIdentityServerAuthentication(option =>
                {
                    option.Authority = "http://localhost:5000";
                    option.RequireHttpsMetadata = false;
                    option.ApiSecret = "time_tracking";
                    option.ApiName = "time_tracking";
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Time Tracking API V1");
            });

            app.UseMvc();
        }
    }
}
