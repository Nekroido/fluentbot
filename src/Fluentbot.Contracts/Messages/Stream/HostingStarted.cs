namespace Fluentbot.Contracts.Messages.Stream
{
    public record HostingStarted
    {
        public string HostingChannel { get; init; }

        public string TargetChannel { get; init; }

        public uint Viewers { get; init; }
    }
}