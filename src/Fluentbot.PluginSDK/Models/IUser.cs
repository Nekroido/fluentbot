using System.Collections.Generic;

namespace Fluentbot.PluginSDK.Models
{
    public interface IUser
    {
        string Id { get; }

        string Username { get; }

        string DisplayName { get; }

        IEnumerable<IUserRole> Roles { get; }

        IEnumerable<IDebuff> Debuffs { get; }
    }
}