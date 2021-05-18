using System;

namespace Fluentbot.PluginSDK.Models
{
    /// <summary>
    /// Defines a chat debuff like mute or ban.
    /// </summary>
    public interface IDebuff
    {
        /// <summary>
        /// User that applied this debuff to the current chatter.
        /// </summary>
        IUser AppliedBy { get; }

        string Note { get; }

        string DisplayReason { get; }

        DateTime? ExpiresAt { get; }
    }
}