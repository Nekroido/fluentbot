using System;

namespace Fluentbot.Contracts.Messages.Chat
{
    public record ChannelJoined
    {
        public string Channel { get; init; }
        
        public DateTime JoinedAt { get; init; } = DateTime.Now;
    }
}