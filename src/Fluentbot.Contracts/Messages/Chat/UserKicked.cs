using System;
using Fluentbot.Contracts.Models;

namespace Fluentbot.Contracts.Messages.Chat
{
    public record UserKicked
    {
        public User KickedBy { get; init; }
        
        public User User { get; init; }
        
        public string Reason { get; init; }
        
        public DateTime KickedAt { get; init; }
    }
}
