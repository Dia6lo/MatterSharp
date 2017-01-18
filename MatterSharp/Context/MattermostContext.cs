using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatterSharp.Context.Models;

namespace MatterSharp.Context
{
    public class MattermostContext
    {
        private readonly MattermostClient client;

        public MattermostContext(Uri uri)
        {
            client = new MattermostClient(uri);
            InitializeRepositories();
        }

        public MattermostContext(Uri uri, string token)
        {
            client = new MattermostClient(uri, token);
            InitializeRepositories();
        }

        private void InitializeRepositories()
        {
            Users = new SimpleRepository<User>(this, async (context, id) => await context.GetUserAsync(id));
            Teams = new SimpleRepository<Team>(this, async (context, id) => await context.GetTeamAsync(id));
        }

        public Repository<User> Users { get; private set; }

        public Repository<Team> Teams { get; private set; }

        public async Task<User> GetCurrentUserAsync()
        {
            return await Copy<User>(await client.GetCurrentUserAsync());
        }

        public async Task<User> GetUserAsync(string id)
        {
            // TODO
            return id == "" ? null : await Copy<User>(await client.GetUserAsync(id));
        }

        public async Task<List<Team>> GetAllTeamsAsync()
        {
            var teams = await client.GetAllTeamsAsync();
            var copies = await Task.WhenAll(teams.Select(async t => await Copy<Team>(t)));
            return copies.ToList();
        }

        public async Task<Team> GetTeamAsync(string id)
        {
            // TODO
            return id == "" ? null : await Copy<Team>(await client.GetTeamAsync(id));
        }

        public async Task<List<Channel>> GetAllChannelsAsync(string teamId)
        {
            var channels = await client.GetAllChannelsAsync(teamId);
            var copies = await Task.WhenAll(channels.Select(async t => await Copy<Channel>(t)));
            return copies.ToList();
        }

        public async Task<Channel> GetChannelAsync(string teamId, string id)
        {
            // TODO
            return id == "" ? null : await Copy<Channel>(await client.GetChannelAsync(teamId, id));
        }

        public async Task<List<Post>> GetPostsForChannelAsync(string teamId, string channelId, int offset, int limit)
        {
            var posts = await client.GetPostsForChannelAsync(teamId, channelId, offset, limit);
            var copies = await Task.WhenAll(posts.Select(async t => await Copy<Post>(t)));
            return copies.ToList();
        }

        public async Task<Post> GetPostAsync(string teamId, string channelId, string id)
        {
            // TODO
            return id == "" ? null : await Copy<Post>(await client.GetPostAsync(teamId, channelId, id));
        }

        private async Task<T> Copy<T>(object source) where T : new()
        {
            var result = new T();
            foreach (var property in source.GetType().GetProperties())
            {
                property.SetValue(result, property.GetValue(source, null), null);
            }
            var fetcher = result as IReferenceFetcher;
            if (fetcher != null)
            {
                await fetcher.FetchReferences(this);
            }
            return result;
        }
    }
}
