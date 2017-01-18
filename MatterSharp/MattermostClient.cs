using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatterSharp.Models;
using MatterSharp.Rest;

namespace MatterSharp
{
    public class MattermostClient
    {
        private readonly MattermostRestClient restClient;

        public MattermostClient(Uri uri)
        {
            restClient = new MattermostRestClient(uri);
        }

        public MattermostClient(Uri uri, string token)
        {
            restClient = new MattermostRestClient(uri, token);
        }
        
        public async Task<User> GetCurrentUserAsync()
        {
            return new User(await restClient.GetCurrentUserAsync());
        }

        public async Task<User> GetUserAsync(string id)
        {
            return new User(await restClient.GetUserAsync(id));
        }

        public async Task<List<Team>> GetAllTeamsAsync()
        {
            return (await restClient.GetAllTeamsAsync())
                .Select(kvp => new Team(kvp.Value))
                .ToList();
        }

        public async Task<Team> GetTeamAsync(string id)
        {
            return new Team(await restClient.GetTeamAsync(id));
        }

        public async Task<List<Channel>> GetAllChannelsAsync(string teamId)
        {
            return (await restClient.GetAllChannelsAsync(teamId))
                .Channels
                .Select(c => new Channel(c))
                .ToList();
        }

        public async Task<Channel> GetChannelAsync(string teamId, string id)
        {
            return new Channel(await restClient.GetChannelAsync(teamId, id));
        }

        public async Task<List<Post>> GetPostsForChannelAsync(string teamId, string channelId, int offset, int limit)
        {
            var posts = await restClient.GetPostsForChannelAsync(teamId, channelId, offset, limit);
            return posts.Order
                .Select(id => new Post(posts.Posts[id]))
                .ToList();
        }

        public async Task<Post> GetPostAsync(string teamId, string channelId, string id)
        {
            return new Post(await restClient.GetPostAsync(teamId, channelId, id));
        }
    }
}
