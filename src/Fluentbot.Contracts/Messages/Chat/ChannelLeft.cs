using System;

namespace Fluentbot.Contracts.Messages.Chat
{
    public record ChannelLeft
    {
        public string Channel { get; init; }

        public DateTime LeftAt { get; init; } = DateTime.Now;
    }
}