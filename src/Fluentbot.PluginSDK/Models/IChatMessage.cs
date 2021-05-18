using System;

namespace Fluentbot.PluginSDK.Models
{
    public interface IChatMessage
    {
        string Content { get; }
        
        DateTime Timestamp { get; }
    }
}