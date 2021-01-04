using System;
using Fluentbot.Contracts.Models;

namespace Fluentbot.Contracts.Messages.Chat
{
    public record PermissionRevoked
    {
        public User RevokedBy { get; init; }
        
        public User User { get; init; }
        
        public DateTime RevokedAt { get; init; }
    }
}
