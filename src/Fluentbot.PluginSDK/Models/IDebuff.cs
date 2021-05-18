using System;

namespace Fluentbot.PluginSDK.Models
{
    public interface IDebuff
    {
        IUser AppliedBy { get; }

        string Note { get; }

        string DisplayReason { get; }

        DateTime? ExpiresAt { get; }
    }
}