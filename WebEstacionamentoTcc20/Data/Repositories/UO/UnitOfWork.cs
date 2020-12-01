using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebEstacionamentoTcc20.Models;

namespace WebEstacionamentoTcc20.Data.Repositories.UO
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ControleContext _wrContext;

        public UnitOfWork()
        {
            _wrContext = new ControleContext();
        }

        public void Save()
        {
            _wrContext.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _wrContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public ControleContext Context
        {
            get { return _wrContext; }
        }

    }
}