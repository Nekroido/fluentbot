using System;
using Fluentbot.Contracts.Models;

namespace Fluentbot.Contracts.Messages.Chat
{
    public record PermissionAssigned
    {
        public User AssignedBy { get; init; }
        
        public User User { get; init; }
        
        public DateTime AssignedAt { get; init; }
    }
}
