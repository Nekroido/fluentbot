using System;

namespace Fluentbot.PluginSDK.Conditions
{
    public interface ICondition
    {
        Func<IMessage, IContext, bool> Condition { get; }
    }

    public interface IConditionSet : ICondition
    {
        ConditionKind ConditionKind { get; }
    }

    public enum ConditionKind
    {
        And,
        Or
    }
}
