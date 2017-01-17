using System;
using RestSharp;

namespace MatterSharp
{
    public class MattermostClient
    {
        private readonly RestClient restClient;
        private readonly Uri serverUri;
        private readonly Uri apiUri;
        private readonly string token;

        public MattermostClient(Uri uri)
        {
            serverUri = uri;
            apiUri = new Uri(serverUri, "api/v3");
            restClient = new RestClient(apiUri);
            restClient.AddHandler("application/json", new MattermostJsonDeserializer());
        }

        public MattermostClient(Uri uri, string token): this(uri)
        {
            this.token = token;
        }

        private T Execute<T>(IRestRequest request) where T: new()
        {
            request.AddParameter("Authorization", $"Bearer {token}", ParameterType.HttpHeader);
            var result = restClient.Execute<T>(request);
            return result.Data;
        }

        public User GetCurrentUser()
        {
            var request = new RestRequest("users/me", Method.GET);
            return Execute<User>(request);
        }
    }
}
