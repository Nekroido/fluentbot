using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Fluentbot.Contracts.Messages.Stream;
using MassTransit;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TwitchLib.PubSub;

namespace Fluentbot.ChatService.Twitch
{
    public class TwitchPubSubHostedService : IHostedService
    {
        private readonly IBus _bus;
        private readonly TwitchPubSub _client;
        private readonly IOptionsMonitor<TwitchSection> _config;
        private readonly ILogger<TwitchPubSubHostedService> _logger;
        private readonly IMapper _mapper;

        public TwitchPubSubHostedService(
            IOptionsMonitor<TwitchSection> config,
            ILogger<TwitchPubSubHostedService> logger,
            IBus bus,
            IMapper mapper
        )
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _bus = bus ?? throw new ArgumentNullException(nameof(bus));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _client = new TwitchPubSub();

            SubscribeToTopics();
            RegisterListeners();

            _config.OnChange(s => SubscribeToTopics());
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _client.Connect();
            _logger.LogInformation("Connected to Twitch Pub/Sub");
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            _client.Disconnect();
            _logger.LogInformation("Disconnected from Twitch Pub/Sub");
        }

        private void SubscribeToTopics()
        {
            foreach (var channel in _config.CurrentValue.EnabledChannels)
                _client.ListenToVideoPlayback(channel);
        }

        private void RegisterListeners()
        {
            _client.OnPubSubServiceConnected += (s, e) => _client.SendTopics();
            _client.OnListenResponse += (s, e) =>
            {
                if (!e.Successful)
                    _logger.LogCritical($"Failed to listen! Response: {e.Response}");
            };

            _client.OnStreamUp += async (s, e) => await _bus.Publish(_mapper.Map<StreamStarted>(e));
            _client.OnStreamDown += async (s, e) => await _bus.Publish(_mapper.Map<StreamEnded>(e));

            _client.OnRaidGo += async (s, e) => await _bus.Publish(_mapper.Map<RaidReceived>(e));
        }
    }
}