using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PBZ_Lab2.Domain.Infrastructure
{
    public interface IRepository<TEntity, in TKey>
        where TEntity : class, IBaseEntity<TKey>
    {
        TEntity Add(TEntity entity);

        void Delete(TEntity entity);

        IQueryable<TEntity> GetAll();

        TEntity GetById(TKey id);

        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> where);

        void Update(TEntity entity);

        Task BulkDeleteAsync(Expression<Func<TEntity, bool>> where);

        Task BulkInsertAsync(IEnumerable<TEntity> entities);

        Task BulkUpdateAsync(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TEntity>> updatedEntity);

        void Reload(TEntity entity);
    }

    public interface IRepositoryWithoutKey<TEntity>
        where TEntity : class
    {
        TEntity Add(TEntity entity);

        void Delete(TEntity entity);

        IQueryable<TEntity> GetAll();

        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> where);

        void Update(TEntity entity);

        Task BulkDeleteAsync(Expression<Func<TEntity, bool>> where);

        Task BulkInsertAsync(IEnumerable<TEntity> entities);

        Task BulkUpdateAsync(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TEntity>> updatedEntity);

        void Reload(TEntity entity);
    }
}