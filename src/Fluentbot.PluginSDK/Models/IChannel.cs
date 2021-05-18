using System.Linq;

namespace Fluentbot.PluginSDK.Models
{
    public interface IChannel
    {
        string Id { get; }

        string Name { get; }

        // TODO: Maybe?
        IQueryable<IChatMessage> AllMessages { get; }
    }
}