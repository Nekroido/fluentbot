namespace Fluentbot.PluginSDK
{
    public interface IMessage
    {
        string EventName { get; }

        object Payload { get; }
    }
}
