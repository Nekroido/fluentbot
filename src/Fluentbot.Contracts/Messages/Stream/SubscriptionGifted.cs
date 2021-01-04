using Fluentbot.Contracts.Models;

namespace Fluentbot.Contracts.Messages.Stream
{
    public record SubscriptionGifted
    {
        public User GiftedBy { get; init; }

        public User GiftedTo { get; init; }
    }
}