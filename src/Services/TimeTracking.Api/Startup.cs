using Autofac;
using Autofac.Extensions.DependencyInjection;
using Krola.Core.Data;
using Krola.Core.Data.Interfaces;
using Krola.Core.Infrastructure;
using Krola.Core.Infrastructure.Interfaces;
using Krola.Core.Infrastructure.Services;
using Krola.Data.TimeTracking;
using Krola.TimeTracking.Api.Interfaces;
using Krola.TimeTracking.Api.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;

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
        // public IServiceProvider ConfigureServices(IServiceCollection services)
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TimeTrackingDbContext>(options => DbContextOptionsBuilderFactory.Create<TimeTrackingDbContext>());

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TimeTracking API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                     {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                     }
                });

                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });
            services.AddSingleton(typeof(TimeTrackingDbContextFactory));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient(typeof(IRepository<>), typeof(TimeTrackingRepository<>));
            services.AddTransient<IDeviceService, DeviceService>();
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IHttpContextUserProvider, HttpContextUserProvider>();
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddAuthentication("Bearer")
                .AddIdentityServerAuthentication(option =>
                {
                    option.Authority = "http://192.168.1.104:5000";
                    option.RequireHttpsMetadata = false;
                    option.ApiSecret = "time_tracking";
                    option.ApiName = "time_tracking";
                });

            var builder = new ContainerBuilder();
            builder.Populate(services);
            builder.RegisterModule<InfrastructureModule>();
            var container = builder.Build();

            return new AutofacServiceProvider(container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostEnvironment env)
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
