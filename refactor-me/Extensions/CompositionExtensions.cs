using System.Reflection;
using Autofac;
using Autofac.Builder;
using Autofac.Features.Scanning;
using refactor_me.Enums;
using refactor_me.Attributes;

namespace refactor_me.Extensions
{
    /// <summary>
    /// Provides automatic component registration by scanning assemblies and types for
    /// those that have the <see cref="ComponentAttribute"/> annotation.
    /// </summary>
    public static class CompositionExtensions
    {
        /// <summary>
        /// Registers the components found in the given assemblies for the given scope
        /// </summary>
        private static IRegistrationBuilder<object, ScanningActivatorData, DynamicRegistrationStyle> RegisterAssemblyComponents(this ContainerBuilder builder, Assembly[] assemblies, ScopeEnum scope)
        {

            return builder.RegisterAssemblyTypes(assemblies)
                .Where(t =>
                {
                    if (t.IsDefined(typeof(ComponentAttribute), false))
                    {
                        return t.GetScope() == scope;
                    }
                    return false;
                });
        }


        /// <summary>
        /// Registers all the transient components in the array of dependencies
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="assemblies"></param>
        /// <returns></returns>
        public static IRegistrationBuilder<object, ScanningActivatorData, DynamicRegistrationStyle> RegisterTransientComponents(this ContainerBuilder builder, params Assembly[] assemblies)
        {
            return builder.RegisterAssemblyComponents(assemblies, ScopeEnum.Transient);
        }


        /// <summary>
        /// Registers all the request components in the array of dependencies
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="assemblies"></param>
        /// <returns></returns>
        public static IRegistrationBuilder<object, ScanningActivatorData, DynamicRegistrationStyle> RegisterRequestComponents(this ContainerBuilder builder, params Assembly[] assemblies)
        {
            return builder.RegisterAssemblyComponents(assemblies, ScopeEnum.Request);
        }


        /// <summary>
        /// Registers all the shared components in the array of dependencies
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="assemblies"></param>
        /// <returns></returns>
        public static IRegistrationBuilder<object, ScanningActivatorData, DynamicRegistrationStyle> RegisterSharedComponents(this ContainerBuilder builder, params Assembly[] assemblies)
        {
            return builder.RegisterAssemblyComponents(assemblies, ScopeEnum.Shared);
        }

        /// <summary>
        /// Registers all the singleton components in the array of dependencies
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="assemblies"></param>
        /// <returns></returns>
        public static IRegistrationBuilder<object, ScanningActivatorData, DynamicRegistrationStyle> RegisterSingletonComponents(this ContainerBuilder builder, params Assembly[] assemblies)
        {
            return builder.RegisterAssemblyComponents(assemblies, ScopeEnum.Singleton);
        }
    }
}