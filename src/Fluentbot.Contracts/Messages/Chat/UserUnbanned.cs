using System;
using Fluentbot.Contracts.Models;

namespace Fluentbot.Contracts.Messages.Chat
{
    public record UserUnbanned
    {
        public User UnbannedBy { get; init; }
        
        public User User { get; init; }
        
        public DateTime UnbannedAt { get; init; }
    }
}
