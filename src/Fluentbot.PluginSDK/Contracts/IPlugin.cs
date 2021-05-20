using System;

namespace Fluentbot.PluginSDK.Contracts
{
    public interface IPlugin : IDefinesScopes
    {
        string Name { get; }

        string Description { get; }

        string Author { get; }

        Version Version { get; }
    }
}