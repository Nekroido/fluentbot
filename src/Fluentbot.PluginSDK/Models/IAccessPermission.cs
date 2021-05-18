using Fluentbot.PluginSDK.Flags;

namespace Fluentbot.PluginSDK.Models
{
    public interface IAccessPermission
    {
        string Name { get; }
        
        string Description { get; }
        
        ReadWrite Flags { get; }
    }
}