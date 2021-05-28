using System;
using Microsoft.Extensions.Configuration;

namespace Fluentbot.PluginSDK
{
    public interface IPlugin
    {
        string Name { get; }

        string Description { get; }

        string Version { get; }

        string Author { get; }

        Type ConfigurationDefinition { get; }
    }
}
