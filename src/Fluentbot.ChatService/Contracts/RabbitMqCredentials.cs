namespace Fluentbot.ChatService.Contracts
{
    public record RabbitMqCredentials
    {
        public string Host { get; init; }

        public uint Port { get; init; }

        public string User { get; init; }

        public string Password { get; init; }
    }
}