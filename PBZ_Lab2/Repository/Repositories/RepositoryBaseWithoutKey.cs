using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EnsureThat;
using Microsoft.EntityFrameworkCore;
using PBZ_Lab2.Domain.Infrastructure;
using PBZ_Lab2.Web.Data;
using PBZ_Lab2.Web.Domain.Models;
using Z.EntityFramework.Plus;

namespace PBZ_Lab2.SQLRepository.Repositories
{
    public abstract class RepositoryBaseWithoutKey<TEntity> : IRepositoryWithoutKey<TEntity>
        where TEntity : class, new()
    {
        protected readonly DbSet<TEntity> dbset;


        protected RepositoryBaseWithoutKey(PBZ_Lab2WebContext dataContext)
        {
            Ensure.That(dataContext, "dataContext").IsNotNull();

            DataContext = dataContext;
            this.dbset = this.DataContext.Set<TEntity>();
        }

        protected PBZ_Lab2WebContext DataContext { get; private set; }

        public virtual TEntity Add(TEntity entity)
        {
            Ensure.That(entity, "entity").IsNotNull();
            this.dbset.Add(entity);
            return entity;
        }

        public virtual void Delete(TEntity entity)
        {
            Ensure.That(entity, "entity").IsNotNull();
            this.dbset.Remove(entity);
        }

        public virtual void Delete(Expression<Func<TEntity, bool>> where)
        {
            Ensure.That(where, "where").IsNotNull();
            IEnumerable<TEntity> objects = this.dbset.Where<TEntity>(where).AsEnumerable();
            foreach (TEntity obj in objects)
            {
                this.dbset.Remove(obj);
            }
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return this.dbset;
        }

        public virtual IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> where)
        {
            Ensure.That(where, "where").IsNotNull();
            return this.dbset.Where(where);
        }

        public virtual void Update(TEntity entity)
        {
            Ensure.That(entity, "entity").IsNotNull();
            this.dbset.Attach(entity);
            DataContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual async Task BulkDeleteAsync(Expression<Func<TEntity, bool>> where)
        {
            Ensure.That(where, "where").IsNotNull();
            await this.dbset.Where(where).DeleteAsync();
        }

        public virtual async Task BulkInsertAsync(IEnumerable<TEntity> entities)
        {
            Ensure.That(entities, "entities").IsNotNull();
            await this.dbset.AddRangeAsync(entities);
        }

        public virtual async Task BulkUpdateAsync(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TEntity>> updatedEntity)
        {
            Ensure.That(where, "where").IsNotNull();
            await this.dbset.Where(where).UpdateAsync(updatedEntity);
        }

        public void Reload(TEntity entity)
        {
            Ensure.That(entity, "entity").IsNotNull();
            DataContext.Entry(entity).Reload();
        }
    }
}