using System;
using System.Linq;
using System.Threading.Tasks;

namespace FigureMvcWebApi.Model.Database.Repository
{
    public interface IRepository<TEntity> : IDisposable
    {
        Task<IQueryable<TEntity>> GetQueryable();

        Task<TEntity> GetById(Guid id);

        Task<Guid> AddOrUpdate(TEntity entity);

        Task Delete(Guid id);
    }
}
