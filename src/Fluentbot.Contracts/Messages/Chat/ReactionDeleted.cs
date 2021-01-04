using System;
using Fluentbot.Contracts.Models;

namespace Fluentbot.Contracts.Messages.Chat
{
    public record ReactionDeleted
    {
        public User User { get; init; }
        
        public DateTime DeletedAt { get; init; }
    }
}
