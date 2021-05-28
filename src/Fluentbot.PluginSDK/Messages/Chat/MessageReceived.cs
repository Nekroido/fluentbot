namespace Fluentbot.PluginSDK.Messages.Chat
{
    public record MessageReceived
    {
        public string Author { get; init; }

        public string Message { get; init; }
    }
}
