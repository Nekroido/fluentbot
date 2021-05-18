using System;
using System.Collections.Generic;
using Fluentbot.PluginSDK.Models;

namespace Fluentbot.PluginSDK.Contracts
{
    public interface IPlugin
    {
        string Name { get; }

        string Description { get; }
        
        string Author { get; }
        
        Version Version { get; }
        
        IEnumerable<IAccessScope> Scopes { get; }
    }
}