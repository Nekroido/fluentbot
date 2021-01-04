using System;
using Fluentbot.Contracts.Models;

namespace Fluentbot.Contracts.Messages.Chat
{
    public record UserMuted
    {
        public User MutedBy { get; init; }
        
        public User User { get; init; }
        
        public string Reason { get; init; }
        
        public DateTime MutedAt { get; init; }
    }
}
