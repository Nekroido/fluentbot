using System;
using Fluentbot.Contracts.Models;

namespace Fluentbot.Contracts.Messages.Chat
{
    public record ChanelCreated
    {
        public User CreatedBy { get; init; }
        
        public DateTime CreatedAt { get; init; }
    }
}
