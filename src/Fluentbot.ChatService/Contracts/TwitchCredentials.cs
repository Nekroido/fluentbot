#nullable enable
namespace Fluentbot.ChatService.Contracts
{
    public record TwitchCredentials
    {
        public string AuthToken { get; init; }

        public string Username { get; init; }
    }
}