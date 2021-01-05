#nullable enable
using System;
using Fluentbot.Contracts.Models;

namespace Fluentbot.Contracts.Messages.Chat
{
    public record UserLeft
    {
        public User User { get; init; }

        public string? ChannelName { get; init; }

        public DateTime LeftAt { get; init; }
    }
}