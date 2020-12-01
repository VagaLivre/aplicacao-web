using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebEstacionamentoTcc20.Data.Repositories.UO;

namespace WebEstacionamentoTcc20.Data.Repositories.Interfaces
{
    public class GenericRepository<TEntity> : IDisposable, IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly UnitOfWork _unitOfWork;

        //protected SysCurimbabaContext _unitOfWork.Context = new SysCurimbabaContext();

        public GenericRepository()
            : this(new UnitOfWork())
        {
        }


        public GenericRepository(UnitOfWork unitofwork)
        {
            _unitOfWork = unitofwork ?? new UnitOfWork();
        }


        public void Add(TEntity obj)
        {
            _unitOfWork.Context.Set<TEntity>().Add(obj);
            //_unitOfWork.Context.Entry(obj).State = EntityState.Added;
            // implantar padrao Unit of Work posteriormente
            _unitOfWork.Save();
        }

        public void AddAll(IEnumerable<TEntity> list)
        {
            _unitOfWork.Context.Set<TEntity>().AddRange(list);
            _unitOfWork.Save();

        }

        public virtual TEntity GetById(int id)
        {
            return _unitOfWork.Context.Set<TEntity>().Find(id);
        }



        public TEntity GetById(string id)
        {
            return _unitOfWork.Context.Set<TEntity>().Find(id);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            // procurar desabilitar tracking (no tracking) de entidades no EF
            // conforme um exemplo em meus favoritos
            return _unitOfWork.Context.Set<TEntity>();
        }

        public virtual void Update(TEntity obj)
        {
            _unitOfWork.Context.Entry(obj).State = EntityState.Modified;
            _unitOfWork.Save();
        }

        public void Remove(TEntity obj)
        {
            try { _unitOfWork.Context.Set<TEntity>().Attach(obj); }
            catch (Exception) { }
            _unitOfWork.Context.Set<TEntity>().Remove(obj);
            _unitOfWork.Save();

        }

        public void RemoverRange(IEnumerable<TEntity> list)
        {
            foreach (TEntity obj in list)
            {
                try { _unitOfWork.Context.Set<TEntity>().Attach(obj); }
                catch (Exception) { }

            }
            _unitOfWork.Context.Set<TEntity>().RemoveRange(list);
            _unitOfWork.Save();
        }


        public void Dispose()
        {


        }

    }
}
