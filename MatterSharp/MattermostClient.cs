using System;
using System.IO;
using RestSharp;

namespace MatterSharp
{
    public class MattermostClient
    {
        private readonly RestClient restClient;

        public MattermostClient(string url, string token)
        {
            var baseUrl = $"{url}api/v3";
            restClient = new RestClient(baseUrl);
            var request = new RestRequest("users/me", Method.GET);
            request.AddParameter("Authorization", $"Bearer {token}", ParameterType.HttpHeader);
            var result = restClient.Execute(request);
            var a = 1;
        }
    }
}
