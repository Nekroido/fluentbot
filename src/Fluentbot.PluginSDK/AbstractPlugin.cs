using System;
using Microsoft.Extensions.Configuration;

namespace Fluentbot.PluginSDK
{
    public abstract class AbstractPlugin : IPlugin
    {
        public abstract string Name { get; }
        public abstract string Description { get; }
        public abstract string Version { get; }
        public abstract string Author { get; }
        public abstract Type ConfigurationDefinition { get; }
    }
}
