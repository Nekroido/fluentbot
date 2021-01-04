using System;
using Fluentbot.Contracts.Models;

namespace Fluentbot.Contracts.Messages.Chat
{
    public record UserJoined
    {
        public User User { get; init; }
        
        public DateTime JoinedAt { get; init; }
    }
}
