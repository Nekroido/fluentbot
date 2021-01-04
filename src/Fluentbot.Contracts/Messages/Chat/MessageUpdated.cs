using System;
using Fluentbot.Contracts.Models;

namespace Fluentbot.Contracts.Messages.Chat
{
    public record MessageUpdated
    {
        public string Id { get; init; }
        
        public User UpdatedBy { get; init; }
        
        public DateTime UpdatedAt { get; init; }
    }
}