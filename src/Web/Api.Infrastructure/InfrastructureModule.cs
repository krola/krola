using Autofac;
using Krola.Web.Api.Core.Interfaces.Gateways.Repositories;
using Krola.Web.Api.Core.Interfaces.Services;
using Krola.Web.Api.Infrastructure.Auth;
using Krola.Web.Api.Infrastructure.Data.Repositories;
using Krola.Web.Api.Infrastructure.Interfaces;
using Krola.Web.Api.Infrastructure.Logging;
using Module = Autofac.Module;

namespace Krola.Web.Api.Infrastructure
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();
            builder.RegisterType<JwtFactory>().As<IJwtFactory>().SingleInstance();
            builder.RegisterType<JwtTokenHandler>().As<IJwtTokenHandler>().SingleInstance();
            builder.RegisterType<TokenFactory>().As<ITokenFactory>().SingleInstance();
            builder.RegisterType<JwtTokenValidator>().As<IJwtTokenValidator>().SingleInstance();
            builder.RegisterType<Logger>().As<ILogger>().SingleInstance();
        }
    }
}
