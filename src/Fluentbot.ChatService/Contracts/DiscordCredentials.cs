namespace Fluentbot.ChatService.Contracts
{
    public record DiscordCredentials
    {
        public string AuthToken { get; init; }
    }
}