using Microsoft.Extensions.DependencyInjection;

namespace Fluentbot.ChatService.Twitch
{
    public class TwitchServiceCollectionConfigurator : ITwitchServiceCollectionConfigurator
    {
        public IServiceCollection Collection { get; init; }

        public TwitchServiceCollectionConfigurator(IServiceCollection collection)
        {
            Collection = collection;
        }

        public void Configure(string authToken, string botName, string channel = default)
        {
            
        }
    }
}