using System;

namespace Fluentbot.PluginSDK.Models
{
    public interface IStreamGamePlatform
    {
        string Name { get; }

        Uri IconUrl { get; }
    }
}