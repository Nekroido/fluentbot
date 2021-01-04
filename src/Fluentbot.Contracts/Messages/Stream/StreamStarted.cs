using System;

namespace Fluentbot.Contracts.Messages.Stream
{
    public record StreamStarted
    {
        public int PlayDelay { get; init; }

        public DateTime? StartedAt { get; init; }
    }
}