using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using System.Web.Http;
using refactor_me.Extensions;

namespace refactor_me
{
    /// <summary>
    /// The autofac configuration containing the setup of the container
    /// </summary>
    public static class IoCConfig
    {
        public static void RegisterDependencies()
        {
            var config = GlobalConfiguration.Configuration;
            var assemblies = new[] { Assembly.GetExecutingAssembly() };

            //Call out to the autofac config to register the dependencies
            SetupContainer(config, assemblies);
        }

        private static void SetupContainer(HttpConfiguration config, Assembly[] assemblies)
        {
            var builder = new ContainerBuilder();

            // Register your Web API controllers.
            builder.RegisterApiControllers(assemblies);

            //Register the components 
            builder.RegisterTransientComponents(assemblies).AsSelf().InstancePerDependency();

            builder.RegisterTransientComponents(assemblies)
                .Where(t => t.GetRegisterAsImplementedInterface())
                .AsImplementedInterfaces()
                .InstancePerDependency();

            builder.RegisterRequestComponents(assemblies).AsSelf().InstancePerLifetimeScope();

            builder.RegisterRequestComponents(assemblies)
                .Where(t => t.GetRegisterAsImplementedInterface())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterSharedComponents(assemblies).AsSelf().InstancePerMatchingLifetimeScope();

            builder.RegisterSharedComponents(assemblies)
                .Where(t => t.GetRegisterAsImplementedInterface())
                .AsImplementedInterfaces()
                .InstancePerMatchingLifetimeScope();

            builder.RegisterSingletonComponents(assemblies).AsSelf().SingleInstance();

            builder.RegisterSingletonComponents(assemblies)
                .Where(t => t.GetRegisterAsImplementedInterface())
                .AsImplementedInterfaces()
                .SingleInstance();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}