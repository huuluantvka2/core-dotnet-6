using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Model.Interfaces;
using System.Linq.Expressions;

namespace Data.Infracstructure
{
    public abstract class RepositoryBase<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>
    {

        private IDbFactory DbFactory;
        private BuildDbContext dataContext { get; set; }
        protected BuildDbContext DbContext { get { return dataContext ?? (dataContext = DbFactory.Init()); } }
        protected DbSet<TEntity> DbSet;

        public RepositoryBase(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
            DbSet = DbContext.Set<TEntity>();
        }
        public void Delete(TKey id)
        {
            var entity = DbSet.Find(id);
            DbSet.Remove(entity);
        }

        public void Delete(TEntity entity)
        {
            DbSet.Remove(entity);
        }

        public void DeleteMulti(IEnumerable<TKey> ids)
        {
            foreach (var id in ids)
            {
                var entity = DbSet.Find(id);
                DbSet.Remove(entity);
            }
        }

        public void DeleteMulti(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                DbSet.Remove(entity);
            }
        }

        public IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = DbContext.Set<TEntity>();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return query.Where(predicate).AsEnumerable();
        }
        public IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public TEntity GetById(TKey id, params Expression<Func<TEntity, object>>[] includes)
        {
            return DbSet.Find(id);
        }

        public IEnumerable<TEntity> GetByIds(IEnumerable<TKey> ids, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = DbSet;
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return query.Where(i => ids.Contains(i.Id));
        }

        public void Insert(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public void Insert(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                DbSet.Add(entity);
            }
        }

        public void Update(TEntity entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Update(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                DbContext.Entry(entity).State = EntityState.Modified;
            }
        }

        public void Update(TEntity entity, params Expression<Func<TEntity, object>>[] properties)
        {
            DbContext.Set<TEntity>().Attach(entity);
            EntityEntry<TEntity> entry = DbContext.Entry(entity);
            foreach (var selector in properties)
            {
                entry.Property(selector).IsModified = true;
            }
        }
    }
}
