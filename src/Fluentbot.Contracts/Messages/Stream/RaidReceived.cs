namespace Fluentbot.Contracts.Messages.Stream
{
    public record RaidReceived
    {
        public string ChannelId { get; init; }

        public string Channel { get; init; }

        public string RaidedByChannel { get; init; }

        public string RaidedByChannelId { get; init; }

        public uint Viewers { get; init; }
    }
}