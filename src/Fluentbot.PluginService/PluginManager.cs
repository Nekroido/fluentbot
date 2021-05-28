using System;
using System.Collections.Generic;
using Fluentbot.PluginSDK;

namespace Fluentbot.PluginService
{
    public class PluginManager
    {
        public PluginManager()
        {
        }

        public IEnumerable<AbstractPlugin> LoadPlugin(string assemblyName)
        {
            var assembly = Type.GetType(assemblyName) ?? throw new ArgumentException(nameof(assemblyName));

            foreach (var type in assembly.GetNestedTypes())
            {
                if (typeof(AbstractPlugin).IsAssignableFrom(type))
                {
                    yield return (AbstractPlugin) Activator.CreateInstance(assembly);
                }
            }
        }
    }
}
