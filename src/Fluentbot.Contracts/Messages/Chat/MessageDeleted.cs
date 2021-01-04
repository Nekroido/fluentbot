using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fluentbot.Contracts.Models;

namespace Fluentbot.Contracts.Messages.Chat
{
    public record MessageDeleted
    {
        public string Id { get; init; }
        
        public User DeletedBy { get; init; }
        
        public DateTime DeletedAt { get; init; }
    }
}
