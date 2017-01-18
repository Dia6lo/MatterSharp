using System.Threading.Tasks;

namespace MatterSharp.Context.Models
{
    public interface IReferenceFetcher
    {
        Task FetchReferences(MattermostContext context);
    }
}