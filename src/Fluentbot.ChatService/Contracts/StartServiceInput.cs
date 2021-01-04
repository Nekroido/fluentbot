#nullable enable
using Fluentbot.Contracts.Flags;
using Oakton;

namespace Fluentbot.ChatService.Contracts
{
    public record StartServiceInput
    {
        [FlagAlias("s")]
        [Description("Type of service")]
        public ServiceType ServiceType { get; init; }

        [FlagAlias("t")]
        [Description("OAuth 2.0 token")]
        public string AuthToken { get; init; }

        [FlagAlias("u")]
        [Description("Bot username in Twitch chat")]
        public string? BotName { get; init; }

        [FlagAlias("c")]
        [Description("(optional) Twitch channel connect to")]
        public string? ChannelName { get; init; }
    }
}