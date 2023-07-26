using Autofac;
using SampleZoo.DataLayer.Context;
using SampleZoo.IOC.Dependencies;
using SampleZoo.Web.PresentationExtensions;

namespace SampleZoo.Web.Modules
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>();
            builder.RegisterContext<SampleZooDbContext>(ConnectionStringNames.Core);
            
            DependencyContainer.RegisterService(builder);
        }
    }
}

