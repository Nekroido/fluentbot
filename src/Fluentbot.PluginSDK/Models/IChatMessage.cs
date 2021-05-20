using System;

namespace Fluentbot.PluginSDK.Models
{
    public interface IChatMessage
    {
        string Id { get; }
        
        string Content { get; }
        
        DateTime Timestamp { get; }
    }
}