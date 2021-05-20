using System.Threading.Tasks;
using Fluentbot.PluginSDK.Models;

namespace Fluentbot.PluginSDK.Contracts
{
    public interface IContextEnricher : IDefinesScopes
    {
        Task<IActionContext> Execute(IActionContext context, params string[] args);
    }
}