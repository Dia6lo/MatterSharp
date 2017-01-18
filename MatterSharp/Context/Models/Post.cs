using System.Threading.Tasks;

namespace MatterSharp.Context.Models
{
    public class Post : MatterSharp.Models.Post, IReferenceFetcher
    {
        public User User { get; set; }

        public Channel Channel { get; set; }

        public async Task FetchReferences(MattermostContext context)
        {
            User = await context.Users.GetAsync(UserId);
        }
    }
}