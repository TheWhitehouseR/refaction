using ProductsApi.Attributes;
using ProductsApi.Enums;
using System;
using System.Linq;

namespace ProductsApi.Extensions
{
    /// <summary>
    /// Extension methods to handle common attribute retrieval
    /// </summary>
    public static class TypeExtensions
    {
        /// <summary>
        /// Gets the component scope from the Component Attribute
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static ScopeEnum GetScope(this Type type)
        {
            if (!type.IsDefined(typeof(ComponentAttribute), false))
            {
                return ScopeEnum.None;
            }

            return type.GetCustomAttributes(typeof(ComponentAttribute), false)
                .Cast<ComponentAttribute>()
                .First()
                .Scope;
        }

        /// <summary>
        /// Gets the value of RegisterAsImplementedInterface from the Component Attribute
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool GetRegisterAsImplementedInterface(this Type type)
        {
            if (!type.IsDefined(typeof(ComponentAttribute), false))
            {
                return false;
            }

            return type.GetCustomAttributes(typeof(ComponentAttribute), false)
                .Cast<ComponentAttribute>()
                .First()
                .RegisterAsImplementedInterface;
        }
    }
}