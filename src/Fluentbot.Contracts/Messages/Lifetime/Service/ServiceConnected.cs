using System;

namespace Fluentbot.Contracts.Messages.Lifetime.Service
{
    public record ServiceConnected
    {
        public DateTime ConnectedAt { get; init; } = DateTime.Now;
    }
}