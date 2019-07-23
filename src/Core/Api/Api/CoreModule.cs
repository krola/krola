using Autofac;
using Krola.Core.Data.Interfaces;

namespace Krola.Core.Data
{
    public class CoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(Repository<,>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
        }
    }
}
