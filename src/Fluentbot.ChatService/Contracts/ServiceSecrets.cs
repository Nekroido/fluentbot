namespace Fluentbot.ChatService.Contracts
{
    public record ServiceSecrets
    {
        public RabbitMqCredentials RabbitMq { get; init; }

        public TwitchCredentials Twitch { get; init; }

        public DiscordCredentials Discord { get; init; }
    }
}