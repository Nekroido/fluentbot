using System;
using Fluentbot.Contracts.Models;

namespace Fluentbot.Contracts.Messages.Chat
{
    public record RoleRemoved
    {
        public User User { get; init; }
        
        public DateTime RemovedAt { get; init; }
    }
}
