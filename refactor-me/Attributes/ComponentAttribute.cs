using refactor_me.Enums;
using System;

namespace refactor_me.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ComponentAttribute : Attribute
    {
        /// <summary>
        /// The scope within the container which the components instance will live on
        /// See scope enum for details
        /// </summary>
        public ScopeEnum Scope { get; set; } = ScopeEnum.Request;

        /// <summary>
        /// If set, the class with this attribute will be registered as itself and the interfaces that it implements
        /// Defaults to true
        /// </summary>
        public bool RegisterAsImplementedInterface { get; set; } = true;
    }
}