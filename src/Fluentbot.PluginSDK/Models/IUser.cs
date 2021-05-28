namespace Fluentbot.PluginSDK.Models
{
    public interface IUser
    {
        public string Id { get; }

        public string Username { get; }

        public string DisplayName { get; }
    }
}
