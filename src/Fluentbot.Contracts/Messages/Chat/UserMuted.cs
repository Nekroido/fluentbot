#nullable enable
using System;
using Fluentbot.Contracts.Models;

namespace Fluentbot.Contracts.Messages.Chat
{
    public record UserMuted
    {
        public User MutedBy { get; init; }

        public User User { get; init; }

        public string? ChannelName { get; init; }

        public string Reason { get; init; }

        public TimeSpan Duration { get; init; }

        public DateTime MutedAt { get; init; }
    }
}