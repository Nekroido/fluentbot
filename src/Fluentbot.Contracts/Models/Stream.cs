using System;
using Fluentbot.Contracts.Flags;

namespace Fluentbot.Contracts.Models
{
    public record Stream
    {
        public string Id { get; init; }
        
        public string Title { get; init; }
        
        public Game Game { get; init; }
        
        public StreamStatus Status { get; init; }
        
        public DateTime? LiveSince { get; init; }
    }
}