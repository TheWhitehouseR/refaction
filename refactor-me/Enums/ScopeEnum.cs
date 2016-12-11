namespace ProductsApi.Enums
{
    /// <summary>
    /// An enum containing the possible different values for a component's scope
    /// </summary>
    public enum ScopeEnum
    {
        /// <summary>
        /// The default value. Should never be used.
        /// </summary>
        None = 0,

        /// <summary>
        ///  The object is created every time it is used.
        /// </summary>
        Transient,

        /// <summary>
        /// The object is created only once for every request
        /// </summary>
        Request,

        /// <summary>
        /// Not sure? 
        /// </summary>
        Shared,

        /// <summary>
        /// The object is created once and that instance is then used for the lifetime of the container.
        /// </summary>
        Singleton
    }
}