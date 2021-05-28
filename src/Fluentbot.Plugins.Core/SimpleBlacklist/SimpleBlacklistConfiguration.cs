namespace Fluentbot.Plugins.Core.SimpleBlacklist
{
    public record SimpleBlacklistConfiguration
    {
        public int DefaultTimeoutInSeconds { get; init; } = 600;

        public string DefaultMessage { get; init; } = "You were timed-out for using a blacklisted phrase.";

        public string DefaultReason { get; init; } = "Using a blacklisted phrase.";
    }
}
