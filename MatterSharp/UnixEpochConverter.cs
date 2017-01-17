using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MatterSharp
{
    public class UnixEpochConverter : DateTimeConverterBase
    {
        private static readonly DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null) return null;
            return epoch.AddSeconds((long)reader.Value / 1000d);
        }
    }
}