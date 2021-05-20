using System.Threading.Tasks;
using Fluentbot.PluginSDK.Models;

namespace Fluentbot.PluginSDK.Contracts
{
    public interface IAction : IDefinesScopes
    {
        Task Execute(IActionContext context, params string[] args);
    }
}