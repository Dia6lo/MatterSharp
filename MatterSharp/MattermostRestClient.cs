using System;
using System.Collections.Generic;
using RestSharp;

namespace MatterSharp
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

        public Dictionary<string, Team> GetAllTeams()
        {
            var request = new RestRequest("teams/all", Method.GET);
            return Execute<Dictionary<string, Team>>(request);
        }

        public ChannelsOfTeam GetAllChannels(string teamId)
        {
            var request = new RestRequest($"teams/{teamId}/channels/", Method.GET);
            return Execute<ChannelsOfTeam>(request);
        }

        public PostsOfAChannel GetPostsForAChannel(string teamId, string channelId, int offset, int limit)
        {
            var request = new RestRequest($"teams/{teamId}/channels/{channelId}/posts/page/{offset}/{limit}", Method.GET);
            return Execute<PostsOfAChannel>(request);
        }
    }
}
