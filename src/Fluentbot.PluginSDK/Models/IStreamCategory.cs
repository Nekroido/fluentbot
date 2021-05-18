using System;
using System.Collections.Generic;

namespace Fluentbot.PluginSDK.Models
{
    public interface IStreamCategory
    {
        string Name { get; }

        Uri CoverArtUrl { get; }

        Uri IconUrl { get; }

        string Description { get; }
        
        IEnumerable<string> Tags { get; }

        IEnumerable<IStreamGamePlatform> GamePlatforms { get; }
    }
}