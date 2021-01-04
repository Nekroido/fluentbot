using System;
using Fluentbot.Contracts.Models;

namespace Fluentbot.Contracts.Messages.Chat
{
    public record UserBanned
    {
        public User BannedBy { get; init; }
        
        public User User { get; init; }
        
        public string Reason { get; init; }

        public DateTime BannedAt { get; init; }
    }
}