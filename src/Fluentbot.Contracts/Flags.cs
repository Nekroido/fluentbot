using System;

namespace Fluentbot.Contracts.Flags
{
    [Flags]
    public enum ServiceType
    {
        Twitch,
        Discord
    }

    public enum StreamStatus
    {
        Offline,
        Online
    }
}