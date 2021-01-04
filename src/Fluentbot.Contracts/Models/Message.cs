using System.Collections.Generic;

namespace Fluentbot.Contracts.Models
{
    public record Message
    {
        public string Id { get; init; }

        public string Body { get; init; }

        public IEnumerable<MessageAttachment> Attachments { get; init; }

        public bool IsMeHighlight { get; init; } = false;
    }
}