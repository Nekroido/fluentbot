using System;

namespace Fluentbot.PluginSDK.Services
{
    public interface IChatService
    {
        #region Message operations

        void SendMessage(string message);
        void SendMessage(string channelId, string message);
        void DeleteMessage(string messageId);

        void AddReaction(string messageId, string reaction);
        void RemoveReaction(string messageId, string reaction);

        #endregion

        #region User operations

        void Timeout(string userId, TimeSpan duration);
        void Timeout(string userId, TimeSpan duration, string reason);
        void Timeout(string userId, TimeSpan duration, string reason, string note);

        void Ban(string userId);
        void Ban(string userId, string reason);
        void Ban(string userId, string reason, string note);

        void KickUser(string userId);
        void KickUser(string userId, string note);

        void AddRole(string userId, string roleId);
        void RemoveRole(string userId, string roleId);

        #endregion
    }
}