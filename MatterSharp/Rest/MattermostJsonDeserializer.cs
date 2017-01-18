using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestSharp;
using RestSharp.Deserializers;

namespace MatterSharp.Rest
{
    public class MattermostJsonDeserializer : IDeserializer
    {
        private static readonly JsonSerializerSettings settings = new JsonSerializerSettings
        {
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            }
        };

        public T Deserialize<T>(IRestResponse response)
        {
            return JsonConvert.DeserializeObject<T>(response.Content, settings);
        }

        public string RootElement { get; set; }

        public string Namespace { get; set; }

        public string DateFormat { get; set; }
    }
}