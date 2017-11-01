using System;
namespace MyBackup
{
    /// <summary>
    /// Handler factory.
    /// </summary>
    public static class HandlerFactory
    {
        /// <summary>
        /// Create the specified key.
        /// </summary>
        /// <returns>The create.</returns>
        /// <param name="key">Key.</param>
        public static IHandler Create(string key)
        {
            return (IHandler)Activator.CreateInstance("MyBackup", $"{key.ToTitleCase()}Handler").Unwrap();
        }
    }
}
