using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLNS.API.Domain.Core.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(Guid id);
        TEntity Create(TEntity entity);
        TEntity Update(TEntity entity);
        Task Delete(Guid id);
        Task<int> SaveChangesAsync();
    }
}
