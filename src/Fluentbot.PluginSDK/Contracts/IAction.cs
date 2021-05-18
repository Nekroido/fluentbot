using System.Threading.Tasks;
using Fluentbot.PluginSDK.Models;

namespace Fluentbot.PluginSDK.Contracts
{
    public interface IAction : IPlugin
    {
        Task Execute(IContext context, params string[] args);
    }
}