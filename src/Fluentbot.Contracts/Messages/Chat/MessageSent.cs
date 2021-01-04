using System;
using Fluentbot.Contracts.Models;

namespace Fluentbot.Contracts.Messages.Chat
{
    public record MessageSent
    {
        public User Author { get; init; }
        
        public DateTime SentAt { get; init; }
    }
}
