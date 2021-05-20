using Fluentbot.PluginSDK.Services;

namespace Fluentbot.PluginSDK.Models
{
    public interface IActionContext
    {
        IChatContext Chat { get; }

        IStreamContext Stream { get; }
        
        object PersistentData { get; }
    }
}