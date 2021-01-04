using Fluentbot.Contracts.Models;

namespace Fluentbot.Contracts.Messages.Stream
{
    public record UserSubscribed
    {
        public User User { get; init; }

        public bool IsResubscribe { get; init; } = false;

        public bool IsGifted { get; init; } = false;

        public int MonthsTotal { get; init; } = 0;

        public int MonthsStreak { get; init; } = 0;
    }
}
