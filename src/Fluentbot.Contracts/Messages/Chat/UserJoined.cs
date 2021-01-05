#nullable enable
using System;
using Fluentbot.Contracts.Models;

namespace Fluentbot.Contracts.Messages.Chat
{
    public record UserJoined
    {
        public User User { get; init; }

        public string? ChannelName { get; init; } = default;

        public DateTime JoinedAt { get; init; }
    }
}