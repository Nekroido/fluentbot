using System;
using Fluentbot.Contracts.Models;

namespace Fluentbot.Contracts.Messages.Chat
{
    public record ChannelDeleted
    {
        public User DeletedBy { get; init; }
        
        public DateTime DeletedAt { get; init; }
    }
}
