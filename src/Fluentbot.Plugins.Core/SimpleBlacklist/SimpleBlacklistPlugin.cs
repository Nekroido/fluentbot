using System;
using Fluentbot.PluginSDK;
using Fluentbot.PluginSDK.Attributes;
using Fluentbot.PluginSDK.Messages.Chat;

namespace Fluentbot.Plugins.Core.SimpleBlacklist
{
    public class SimpleBlacklistPlugin : AbstractPlugin
    {
        public override string Name => "Simple blacklist plugin";
        public override string Description => "Simple blacklist plugin";
        public override string Version => "0.1";
        public override string Author => "Nekroido";

        public Func<IMessage, IContext, bool> CatchAllCondition = (_, _) => true;

        public override Type ConfigurationDefinition => typeof(SimpleBlacklistConfiguration);

        [When(typeof(MessageReceived), condition: nameof(CatchAllCondition))]
        public void OnNewMessage(MessageReceived message, IContext context)
        {
        }
    }
}
