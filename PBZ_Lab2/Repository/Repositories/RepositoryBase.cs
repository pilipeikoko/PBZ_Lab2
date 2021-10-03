using PBZ_Lab2.Domain.Infrastructure;
using PBZ_Lab2.Web.Data;

namespace PBZ_Lab2.SQLRepository.Repositories
{
    public abstract class RepositoryBase<TEntity, TKey> : RepositoryBaseWithoutKey<TEntity>, IRepository<TEntity, TKey>
        where TEntity : class, IBaseEntity<TKey>, new()
    {
        protected RepositoryBase(PBZ_Lab2WebContext context)
            : base(context)
        {
        }

        public virtual TEntity GetById(TKey id)
        {
            return this.dbset.Find(id);
        }
    }
}