using System;

namespace Fluentbot.Contracts.Messages.Stream
{
    public record StreamEnded
    {
        public DateTime? EndedAt { get; init; }
    }
}
