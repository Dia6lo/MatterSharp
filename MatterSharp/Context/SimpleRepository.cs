using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MatterSharp.Context
{
    public class SimpleRepository<T> : Repository<T>
    {
        private readonly MattermostContext context;
        private readonly Func<MattermostContext, string, Task<T>> getter;
        private readonly Dictionary<string, T> cache = new Dictionary<string, T>();

        public SimpleRepository(MattermostContext context, Func<MattermostContext, string, Task<T>> getter)
        {
            this.context = context;
            this.getter = getter;
        }

        public override async Task<T> GetAsync(string id)
        {
            T result;
            if (cache.TryGetValue(id, out result))
            {
                return result;
            }
            
            result = await getter(context, id);
            cache[id] = result;
            return result;
        }
    }
}