using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Fluentbot.ChatService.Contracts;
using Fluentbot.Contracts.Messages.Chat;
using Fluentbot.Contracts.Messages.Lifetime.Service;
using Fluentbot.Contracts.Messages.Stream;
using MassTransit;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TwitchLib.Client;
using TwitchLib.Client.Models;
using HostingStarted = Fluentbot.Contracts.Messages.Stream.HostingStarted;

namespace Fluentbot.ChatService.Twitch
{
    public class TwitchHostedService : IHostedService
    {
        private readonly IBus _bus;
        private readonly IOptionsMonitor<TwitchSection> _config;
        private readonly IOptionsMonitor<TwitchCredentials> _credentials;
        private readonly ILogger<TwitchHostedService> _logger;
        private readonly IMapper _mapper;
        private readonly TwitchClient _client;

        public TwitchHostedService(
            IOptionsMonitor<TwitchCredentials> credentials,
            IOptionsMonitor<TwitchSection> config,
            ILogger<TwitchHostedService> logger,
            IBus bus,
            IMapper mapper
        )
        {
            _credentials = credentials ?? throw new ArgumentNullException(nameof(credentials));
            _config = config ?? throw new ArgumentNullException(nameof(config));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _bus = bus ?? throw new ArgumentNullException(nameof(bus));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

            _client = new TwitchClient();

            Initialize();
            RegisterListeners();

            _config.OnChange(s => JoinChannels());
            _credentials.OnChange(s =>
            {
                // Handle credentials reload
            });
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested) return;

            try
            {
                _logger.LogInformation("Connecting to Twitch");
                _client.Connect();
                _logger.LogInformation("Connected to Twitch");

                cancellationToken.Register(async () => await StopAsync());
            }
            catch (Exception e)
            {
                _logger.LogCritical($"Error connecting to Twitch: {e.Message}");
            }
        }

        public async Task StopAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                _logger.LogInformation("Disconnecting from Twitch");
                await Task.Run(() => _client.Disconnect()).ConfigureAwait(true);
                _logger.LogInformation("Disconnected from Twitch");
            }
            catch (Exception e)
            {
                _logger.LogCritical($"Error disconnecting from Twitch: {e.Message}");
            }
        }

        private void Initialize()
        {
            if (_client.IsInitialized)
            {
                _logger.LogWarning("Client is already initialized");
                return;
            }

            _client.Initialize(
                new ConnectionCredentials(_credentials.CurrentValue.Username, _credentials.CurrentValue.AuthToken)
            );
        }

        private void JoinChannels()
        {
            if (_client.IsInitialized == false)
            {
                _logger.LogWarning("Client is not initialized!");
                return;
            }

            var joinedChannels = _client.JoinedChannels.Select(x => x.Channel).ToArray();

            var channelsToJoin = _config.CurrentValue.EnabledChannels.Except(joinedChannels);
            var channelsToLeave = joinedChannels.Except(_config.CurrentValue.EnabledChannels);

            foreach (var channel in channelsToLeave) _client.LeaveChannel(channel);
            foreach (var channel in channelsToJoin) _client.JoinChannel(channel);
        }

        private void RegisterListeners()
        {
            _client.OnConnectionError += async (s, e) =>
            {
                _logger.LogCritical(e.Error.Message);
                await _bus.Publish(_mapper.Map<ServiceCrashed>(e));
            };
            _client.OnConnected += async (s, e) =>
            {
                await _bus.Publish(_mapper.Map<ServiceConnected>(e));

                JoinChannels();
            };
            _client.OnJoinedChannel += async (s, e) =>
            {
                _logger.LogInformation($"Joined {e.Channel}@twitch");
                await _bus.Publish(_mapper.Map<ChannelJoined>(e));
            };
            _client.OnLeftChannel += async (s, e) =>
            {
                _logger.LogInformation($"Left {e.Channel}@twitch");
                await _bus.Publish(_mapper.Map<ChannelLeft>(e));
            };

            _client.OnMessageReceived += async (s, e) =>
            {
                _logger.LogInformation($"@{e.ChatMessage.Username}: {e.ChatMessage.Message}");
                await _bus.Publish(_mapper.Map<MessageReceived>(e));
            };
            _client.OnWhisperReceived += async (s, e) => await _bus.Publish(_mapper.Map<WhisperReceived>(e));

            _client.OnHostingStarted += async (s, e) => await _bus.Publish(_mapper.Map<HostingStarted>(e));
            _client.OnHostingStopped += async (s, e) => await _bus.Publish(_mapper.Map<HostingStopped>(e));

            _client.OnBeingHosted += async (s, e) => await _bus.Publish(_mapper.Map<HostingReceived>(e));
        }
    }
}