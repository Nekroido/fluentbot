namespace Fluentbot.PluginSDK.Models
{
    public interface IGuild
    {
        long Id { get; }

        string Name { get; }

        string Description { get; }
    }
}
