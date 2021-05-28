using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fluentbot.PluginSDK
{
    public interface IContext
    {
        IDictionary<string, string> Meta { get; }

        Task SendMessage(string message);
    }
}
