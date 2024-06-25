using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FigureMvcWebApi.Model.Database.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly FigureDbContext _dbContext;

        protected Repository(FigureDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public Task<IQueryable<TEntity>> GetQueryable() => Task.FromResult(_dbContext.Set<TEntity>().AsQueryable());
        
        public virtual async Task<TEntity> GetById(Guid id) => await _dbContext.Set<TEntity>().FindAsync(id);

        public virtual async Task Delete(Guid id)
        {
            var entity = await GetById(id);
            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task<Guid> AddOrUpdate(TEntity entity)
        {
            _dbContext.Set<TEntity>().AddOrUpdate(entity);
            await _dbContext.SaveChangesAsync();
            return ((IEntity)entity).Id;
        }

        public virtual void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
