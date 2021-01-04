using System;
using Fluentbot.Contracts.Models;

namespace Fluentbot.Contracts.Messages.Chat
{
    public record RoleReceived
    {
        public User User { get; init; }
        
        public DateTime ReceivedAt { get; init; }
    }
}
