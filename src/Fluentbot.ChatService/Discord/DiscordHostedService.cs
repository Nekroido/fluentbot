using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Discord;
using Discord.WebSocket;
using Fluentbot.ChatService.Contracts;
using Fluentbot.Contracts.Messages.Chat;
using Fluentbot.Contracts.Messages.Lifetime.Service;
using MassTransit;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Fluentbot.ChatService.Discord
{
    public class DiscordHostedService : IHostedService
    {
        private readonly IBus _bus;
        private readonly DiscordSocketClient _client;
        private readonly IOptionsMonitor<DiscordCredentials> _credentials;
        private readonly ILogger<DiscordHostedService> _logger;
        private readonly IMapper _mapper;

        public DiscordHostedService(
            IOptionsMonitor<DiscordCredentials> credentials,
            IBus bus,
            ILogger<DiscordHostedService> logger,
            IMapper mapper
        )
        {
            _credentials = credentials ?? throw new ArgumentNullException(nameof(credentials));
            _bus = bus ?? throw new ArgumentNullException(nameof(bus));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

            _client = new DiscordSocketClient();

            _credentials.OnChange(async s =>
            {
                // TODO: Check if stopping the client is required
                await Logout();
                await Login();
            });

            RegisterListeners();
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await Login();

            await _client.StartAsync();
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await Logout();

            await _client.StopAsync();
        }

        private void RegisterListeners()
        {
            _client.Connected += async () => await _bus.Publish<ServiceConnected>(new { });
            _client.Disconnected += async (e) => await _bus.Publish<ServiceDisconnected>(new {Reason = e.Message});

            _client.MessageReceived += async e =>
            {
                _logger.LogInformation($"@{e.Author.Username}: {e.Content}");
                await _bus.Publish(_mapper.Map<MessageReceived>(e));
            };
        }

        private async Task Login()
        {
            if (_client.LoginState == LoginState.LoggedIn || _client.LoginState == LoginState.LoggingIn)
            {
                _logger.LogInformation("Already logged in! Logging out...");
                await _client.LogoutAsync();
            }

            await _client.LoginAsync(TokenType.Bot, _credentials.CurrentValue.AuthToken);
        }

        private async Task Logout()
        {
            if (_client.LoginState == LoginState.LoggingOut || _client.LoginState == LoginState.LoggedOut)
            {
                _logger.LogWarning("Already logged out!");
                return;
            }

            await _client.LogoutAsync();
        }
    }
}