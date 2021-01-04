namespace Fluentbot.Contracts.Messages.Stream
{
    public record HostingReceived
    {
        public string Channel { get; init; }

        public string HostedByChannel { get; init; }

        public bool IsAutoHosted { get; init; }

        public uint Viewers { get; init; }
    }
}