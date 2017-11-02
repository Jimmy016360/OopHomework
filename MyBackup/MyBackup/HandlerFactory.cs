using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MyBackup
{
    /// <summary>
    /// Handler factory.
    /// </summary>
    public sealed class HandlerFactory
    {
        private static readonly Dictionary<string, Type> HandlerLookup; 

        static HandlerFactory()
        {
            HandlerLookup = Assembly.GetEntryAssembly()
                                    .GetTypes()
                                    .Where(type => type.IsClass &&
                                                   type.IsAbstract == false &&
                                                   typeof(AbstractHandler).IsAssignableFrom(type))
                                    .ToDictionary(type => type.Name, type => type, StringComparer.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Create the specified key.
        /// </summary>
        /// <returns>The create.</returns>
        /// <param name="key">Key.</param>
        public static IHandler Create(string key)
        {
            if (HandlerLookup.TryGetValue($"{key}Handler", out Type type)) {
                return (IHandler)Activator.CreateInstance(type);
            }
            throw new ArgumentException($"Could not find type {key}Handler");
        }
    }
}
