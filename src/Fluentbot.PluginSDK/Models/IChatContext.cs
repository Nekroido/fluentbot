using System.Collections.Generic;
using Fluentbot.PluginSDK.Flags;
using Fluentbot.PluginSDK.Services;

namespace Fluentbot.PluginSDK.Models
{
    public interface IChatContext
    {
        ChatPlatform Platform { get; }
        
        IGuild Guild { get; }
        
        IChannel Channel { get; }

        // TODO: To consider
        IEnumerable<IChannel> AllChannels { get; }

        // TODO: To consider
        IEnumerable<IUser> Chatters { get; }
        
        IChatService ChatServiceInstance { get; }
    }
}