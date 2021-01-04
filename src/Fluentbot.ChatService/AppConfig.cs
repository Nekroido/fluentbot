namespace Fluentbot.ChatService
{
    public record AppConfig
    {
        public ServicesSection Services { get; init; }
    }

    public record ServicesSection
    {
        public TwitchSection Twitch { get; init; }
    }

    public record TwitchSection
    {
        public string[] EnabledChannels { get; init; } = default;
    }
}