using System.Threading.Tasks;

namespace MatterSharp.Context.Models
{
    public class Channel: MatterSharp.Models.Channel, IReferenceFetcher
    {
        public Team Team { get; set; }

        public User Creator { get; set; }

        public async Task FetchReferences(MattermostContext context)
        {
            Team = await context.Teams.GetAsync(TeamId);
            Creator = await context.Users.GetAsync(CreatorId);
        }
    }
}