using System.Collections.Generic;
using Fluentbot.PluginSDK.Models;

namespace Fluentbot.PluginSDK.Contracts
{
    public interface IDefinesScopes
    {
        IEnumerable<IAccessScope> Scopes { get; }
    }
}