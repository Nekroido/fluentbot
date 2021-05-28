using System;
using System.ComponentModel.DataAnnotations;

namespace Fluentbot.PluginSDK.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class WhenAttribute : Attribute
    {
        private readonly Type _event;
        private readonly string _condition;

        public WhenAttribute(Type @event, string condition)
        {
            _event = @event;
            _condition = condition;
        }
    }
}
