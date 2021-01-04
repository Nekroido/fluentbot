using System;
using Fluentbot.Contracts.Models;

namespace Fluentbot.Contracts.Messages.Chat
{
    public record UserBoosted
    {
        public User User { get; init; }
        
        public DateTime BoostedAt { get; init; }
    }
}
