using System.Collections.Generic;

namespace Fluentbot.Contracts.Models
{
    public record User
    {
        public string Id { get; init; }
        
        public string Username { get; init; }

        public string DisplayName { get; init; }
        
        public IEnumerable<UserRole> Roles { get; init; }
    }
}