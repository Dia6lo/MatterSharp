using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MatterSharp.Rest.Models;
using RestSharp;

namespace MatterSharp.Rest
{
    public class MattermostRestClient
    {
        private readonly RestClient restClient;
        private readonly Uri serverUri;
        private readonly Uri apiUri;
        private readonly string token;

        public MattermostRestClient(Uri uri)
        {
            serverUri = uri;
            apiUri = new Uri(serverUri, "api/v3");
            restClient = new RestClient(apiUri);
            restClient.AddHandler("application/json", new MattermostJsonDeserializer());
        }

        public MattermostRestClient(Uri uri, string token): this(uri)
        {
            this.token = token;
        }

        private async Task<T> ExecuteAsync<T>(IRestRequest request) where T: new()
        {
            request.AddParameter("Authorization", $"Bearer {token}", ParameterType.HttpHeader);
            var response = await restClient.ExecuteTaskAsync<T>(request);
            return response.Data;
        }

        public Task<User> GetCurrentUserAsync()
        {
            var request = new RestRequest("users/me", Method.GET);
            return ExecuteAsync<User>(request);
        }

        public Task<Dictionary<string, Team>> GetAllTeamsAsync()
        {
            var request = new RestRequest("teams/all", Method.GET);
            return ExecuteAsync<Dictionary<string, Team>>(request);
        }

        public Task<ChannelsOfTeam> GetAllChannelsAsync(string teamId)
        {
            var request = new RestRequest($"teams/{teamId}/channels/", Method.GET);
            return ExecuteAsync<ChannelsOfTeam>(request);
        }

        public Task<PostsOfChannel> GetPostsForChannelAsync(string teamId, string channelId, int offset, int limit)
        {
            var request = new RestRequest($"teams/{teamId}/channels/{channelId}/posts/page/{offset}/{limit}", Method.GET);
            return ExecuteAsync<PostsOfChannel>(request);
        }
    }
}
