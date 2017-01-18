using System;

namespace MatterSharp
{
    public static class UnixEpochConverter
    {
        private static readonly DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static DateTime Convert(long value)
        {
            return epoch.AddMilliseconds(value);
        }
    }
}