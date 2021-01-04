using Microsoft.Extensions.DependencyInjection;

namespace Fluentbot.ChatService.Twitch
{
    public interface ITwitchServiceCollectionConfigurator
    {
        IServiceCollection Collection { get; }

        public void Configure(string authToken, string botName, string channel = default);
    }
}