namespace Fluentbot.Contracts.Models
{
    public record MessageAttachment
    {
        public enum AttachmentType
        {
            Unknown,
            Link,
            Video,
            Image,
            Rich
        }
        
        public string Id { get; init; }
        
        public AttachmentType Type { get; init; }
        
        public string Description { get; init; }
        
        public object Body { get; init; }
    }
}