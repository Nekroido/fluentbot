using System;

namespace Fluentbot.ChatService.Extensions
{
    public static class ConvertExtensions
    {
        /// <summary>
        ///     Converts Guid string to Guid object
        /// </summary>
        /// <param name="s">Guid in string format</param>
        /// <returns></returns>
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

        /// <summary>
        ///     Converts Unix timestamp in string format to DateTime object
        /// </summary>
        /// <param name="timestamp">Unix timestamp in string format</param>
        /// <returns></returns>
        public static DateTime UnixTimestampToDateTime(this string timestamp)
        {
            long.TryParse(timestamp, out var t);

            return t.UnixTimestampToDateTime();
        }

        /// <summary>
        ///     Converts Unix timestamp to DateTime object
        /// </summary>
        /// <param name="timestamp"></param>
        /// <returns></returns>
        public static DateTime UnixTimestampToDateTime(this long timestamp)
        {
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return origin.AddSeconds(timestamp);
        }
    }
}