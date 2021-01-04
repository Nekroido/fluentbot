using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fluentbot.Contracts.Models;

namespace Fluentbot.Contracts.Messages.Chat
{
    public record MessageReceived
    {
        public string Id { get; init; }
        
        public User Author { get; init; }
        
        public Message Message { get; init; }
        
        public DateTime ReceivedAt { get; init; }
    }
}
