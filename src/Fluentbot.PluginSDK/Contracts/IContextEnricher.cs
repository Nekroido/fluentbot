using System.Threading.Tasks;
using Fluentbot.PluginSDK.Models;

namespace Fluentbot.PluginSDK.Contracts
{
    public interface IContextEnricher : IDefinesScopes
    {
        Task<IContext> Execute(IContext context, params string[] args);
    }
}