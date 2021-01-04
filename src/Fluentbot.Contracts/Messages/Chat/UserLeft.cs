using System;
using Fluentbot.Contracts.Models;

namespace Fluentbot.Contracts.Messages.Chat
{
    public record UserLeft
    {
        public User User { get; init; }
        
        public DateTime LeftAt { get; init; }
    }
}
