#nullable enable
using System;

namespace Fluentbot.Contracts.Messages.Lifetime.Service
{
    public record ServiceDisconnected
    {
        public string? Reason { get; init; } = default;

        public DateTime DisconnectedAt { get; init; } = DateTime.Now;
    }
}