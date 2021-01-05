using System;
using AutoMapper;
using Fluentbot.ChatService.Discord;
using Fluentbot.ChatService.Twitch;
using Microsoft.Extensions.DependencyInjection;

namespace Fluentbot.ChatService.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAutoMapper<T>(this IServiceCollection services)
        {
            return services.AddAutoMapper(typeof(T));
        }

        public static IServiceCollection UsingTwitch(this IServiceCollection services,
            Action<ITwitchServiceCollectionConfigurator> configure = default)
        {
            services.AddAutoMapper<TwitchMappingProfile>();
            services.AddHostedService<TwitchHostedService>();
            services.AddHostedService<TwitchPubSubHostedService>();

            var configurator = new TwitchServiceCollectionConfigurator(services);
            configure?.Invoke(configurator);

            return services;
        }

        public static IServiceCollection UsingDiscord(this IServiceCollection services)
        {
            services.AddAutoMapper<DiscordMappingProfile>();
            services.AddHostedService<DiscordHostedService>();

            return services;
        }
    }
}