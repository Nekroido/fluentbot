using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluentbot.Contracts.Messages.Chat
{
    public record ChannelUpdated
    {
        public DateTime UpdatedAt { get; init; }
    }
}
