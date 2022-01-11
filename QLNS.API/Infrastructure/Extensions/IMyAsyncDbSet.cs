using System;
using System.Threading.Tasks;

namespace QLNS.API.Infrastructure.Extensions
{
    public interface IMyAsyncDbSet<TEntity> where TEntity : class
    {
        Task<Object> FindAsync(params Object[] keyValues);
    }
}
