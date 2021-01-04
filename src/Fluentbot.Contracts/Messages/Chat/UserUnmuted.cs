using System;
using Fluentbot.Contracts.Models;

namespace Fluentbot.Contracts.Messages.Chat
{
    public record UserUnmuted
    {
        public User UnmutedBy { get; init; }
        
        public User User { get; init; }
        
        public DateTime UnmutedAt { get; init; }
    }
}
