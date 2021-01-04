using System.Threading.Tasks;
using Fluentbot.ChatService.Contracts;
using Fluentbot.ChatService.Extensions;
using Fluentbot.ChatService.Integrations;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Fluentbot.ChatService
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await CreateHostBuilder(args).RunConsoleAsync().ConfigureAwait(false);
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((_, c) => { })
                .ConfigureServices((_, services) =>
                {
                    services.AddOptions();
                    services.Configure<TwitchCredentials>(_.Configuration.GetSection("twitch"));
                    services.Configure<TwitchSection>(_.Configuration.GetSection("Services:Twitch"));

                    services.AddMassTransit(mt =>
                    {
                        mt.UsingRabbitMq((context, configurator) =>
                        {
                            configurator.ConfigureEndpoints(context);
                        });
                        mt.AddServiceClient();
                    });

                    services.UsingTwitch();

                    services.AddHostedService<MassTransitHostedService>();
                })
                .UseConsoleLifetime(options => options.SuppressStatusMessages = true);
    }
}