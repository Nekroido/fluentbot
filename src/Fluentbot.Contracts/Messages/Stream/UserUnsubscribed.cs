using Fluentbot.Contracts.Models;

namespace Fluentbot.Contracts.Messages.Stream
{
    public record UserUnsubscribed
    {
        public User User { get; init; }
    }
}
