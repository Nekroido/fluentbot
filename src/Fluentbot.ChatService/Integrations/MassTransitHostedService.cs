using System.Threading;
using System.Threading.Tasks;
using MassTransit.Registration;
using Microsoft.Extensions.Hosting;

namespace Fluentbot.ChatService.Integrations
{
    public class MassTransitHostedService : IHostedService
    {
        private readonly IBusDepot _busDepot;

        public MassTransitHostedService(IBusDepot busDepot)
        {
            _busDepot = busDepot;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await _busDepot.Start(cancellationToken).ConfigureAwait(false);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await _busDepot.Stop(cancellationToken);
        }
    }
}