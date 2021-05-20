using System;
using System.Collections.Generic;
using Fluentbot.PluginSDK.Flags;
using Fluentbot.PluginSDK.Services;

namespace Fluentbot.PluginSDK.Models
{
    public interface IStreamContext
    {
        StreamPlatform Platform { get; }
        
        string Id { get; }
        
        string Title { get; }

        IStreamCategory Category { get; }

        int Viewers { get; }

        int PeakViewers { get; }

        IEnumerable<string> Tags { get; }

        Uri StreamUrl { get; }

        Uri ThumbnailUrl { get; }

        bool IsLive { get; }

        bool IsFeatured { get; }
        
        IStreamService StreamServiceInstance { get; }
    }
}