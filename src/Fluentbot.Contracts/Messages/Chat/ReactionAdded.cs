using System;
using Fluentbot.Contracts.Models;

namespace Fluentbot.Contracts.Messages.Chat
{
    public record ReactionAdded
    {
        public User User { get; init; }
        
        public DateTime AddedAt { get; init; }
    }
}
