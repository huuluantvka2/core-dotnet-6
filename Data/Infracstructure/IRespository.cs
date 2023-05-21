﻿using Model.Interfaces;
using System.Linq.Expressions;

namespace Data.Infracstructure
{
    public interface IRepository<TEntity, in TKey> where TEntity : IEntity<TKey>
    {
        IQueryable<TEntity> GetAll();

        TEntity GetById(TKey id, params Expression<Func<TEntity, object>>[] includes);

        IEnumerable<TEntity> GetByIds(IEnumerable<TKey> ids, params Expression<Func<TEntity, object>>[] includes);

        IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);

        void Insert(TEntity entity);

        void Insert(IEnumerable<TEntity> entities);

        void Update(TEntity entity);

        void Update(IEnumerable<TEntity> entities);

        void Update(TEntity entity, params Expression<Func<TEntity, object>>[] properties);

        void Delete(TKey id);

        void Delete(TEntity entity);

        void DeleteMulti(IEnumerable<TKey> ids);

        void DeleteMulti(IEnumerable<TEntity> entities);
    }
}
