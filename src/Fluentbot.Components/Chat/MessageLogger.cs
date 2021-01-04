using System.Threading.Tasks;
using Fluentbot.Contracts.Messages.Chat;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace Fluentbot.Components.Chat
{
    public class MessageLogger : IConsumer<MessageReceived>
    {
        private ILogger<MessageLogger> _logger;

        public MessageLogger(ILogger<MessageLogger> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<MessageReceived> context)
        {
            _logger?.LogInformation($"{context.Message.Author.DisplayName}: {context.Message.Message.Body}");

            return Task.CompletedTask;
        }
    }
}