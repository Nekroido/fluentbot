using System;

namespace Fluentbot.ChatService.Extensions
{
    public static class ConvertExtensions
    {
        public static Guid? ToGuid(this string s)
        {
            try
            {
                Guid.TryParse(s, out var result);

                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}