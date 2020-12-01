using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebEstacionamentoTcc20.Data.Repositories.Interfaces
{
    interface IGenericRepository<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        void AddAll(IEnumerable<TEntity> list);
        TEntity GetById(int id);
        TEntity GetById(string id);
        IQueryable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(TEntity obj);
        void RemoverRange(IEnumerable<TEntity> list);
    }
}