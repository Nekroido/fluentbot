using System;
using Fluentbot.Contracts.Models;

namespace Fluentbot.Contracts.Messages.Chat
{
    public record UserStatusChanged
    {
        public User User { get; init; }
        
        public DateTime ChangedAt { get; init; }
    }
}
