using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Fluentbot.Contracts.Messages.Stream;
using MassTransit;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TwitchLib.PubSub;

namespace Fluentbot.ChatService.Twitch
{
    public class TwitchPubSubHostedService : IHostedService
    {
        private readonly ILogger<TwitchPubSubHostedService> _logger;
        private readonly IBus _bus;
        private readonly IMapper _mapper;
        private TwitchPubSub _client;

        public TwitchPubSubHostedService(ILogger<TwitchPubSubHostedService> logger, IBus bus, IMapper mapper)
        {
            _logger = logger;
            _bus = bus;
            _mapper = mapper;
            _client = new TwitchPubSub();

            _client.ListenToVideoPlayback("joystickow");

            RegisterListeners();
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
    }
}