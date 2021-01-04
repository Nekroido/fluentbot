namespace Fluentbot.Contracts.Models
{
    public record UserRolePermission
    {
        public string Id { get; init; }
        
        public string Description { get; init; }
    }
}