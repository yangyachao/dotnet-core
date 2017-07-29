using Autofac;
using YYC.Autofac.Services;
using Microsoft.Extensions.Logging;

namespace YYC.Autofac
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // The generic ILogger<TCategoryName> service was added to the ServiceCollection by ASP.NET Core.
            // It was then registered with Autofac using the Populate method in ConfigureServices.
            builder.Register(c => new ValuesServiceV2(c.Resolve<ILogger<ValuesServiceV2>>()))
                .As<IValuesService>()
                .InstancePerLifetimeScope();
        }
    }
}
