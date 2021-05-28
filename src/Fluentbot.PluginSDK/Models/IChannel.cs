using System.Threading.Tasks;

namespace Fluentbot.PluginSDK.Models
{
    public interface IChannel
    {
        long Id { get; }

        string Name { get; }

        string Description { get; }

        Task SendMessage(string message);

        Task ReplyToMessage(long messageId, string message);
    }
}
