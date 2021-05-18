namespace Fluentbot.PluginSDK.Models
{
    public interface IContext
    {
        IChatContext Chat { get; }

        IStreamContext Stream { get; }
    }
}