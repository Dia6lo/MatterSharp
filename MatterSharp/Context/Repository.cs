using System.Threading.Tasks;

namespace MatterSharp.Context
{
    public abstract class Repository<T>
    {
        public abstract Task<T> GetAsync(string id);
    }
}