using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluentbot.Contracts.Messages.Stream
{
    public record HostingEnded
    {
        public string HostingChannel { get; init; }

        public uint Viewers { get; init; }
    }
}