using System.Collections.Generic;
using Fluentbot.PluginSDK.Flags;

namespace Fluentbot.PluginSDK.Models
{
    public interface IChatContext
    {
        ChatPlatform Platform { get; }
        
        IGuild Guild { get; }
        
        IChannel Channel { get; }

        IEnumerable<IChannel> AllChannels { get; }

        IEnumerable<IUser> Chatters { get; }
    }
}