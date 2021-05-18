using System;

namespace Fluentbot.PluginSDK.Models
{
    public interface IGuild
    {
        string Id { get; }
        
        string Name { get; }
        
        string Description { get; }
        
        Uri IconUrl { get; }
    }
}