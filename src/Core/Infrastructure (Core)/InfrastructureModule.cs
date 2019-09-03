using Autofac;
using Krola.Core.Infrastructure.Interfaces;
using Krola.Core.Infrastructure.Services;

namespace Krola.Core.Infrastructure
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<HttpContextUserProvider>().AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}
