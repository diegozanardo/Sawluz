using System;
using System.Collections.Generic;
using System.Linq;

namespace Sawlux.Service.Base
{
    public interface IServiceBase<TEntity>
    {
        IQueryable<TEntity> GetAll();

        IQueryable<TEntity> Get(Func<TEntity, bool> predicate);

        IQueryable<TEntity> Get(Func<TEntity, bool> predicate, string[] includes);

        TEntity Find(params object[] key);

        void Update(TEntity obj);

        void Save();

        void Add(TEntity obj);

        void Add(List<TEntity> obj);

        void Delete(Func<TEntity, bool> predicate);
    }
}
