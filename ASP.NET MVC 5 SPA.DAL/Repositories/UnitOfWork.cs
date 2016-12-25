using ASP.NET_MVC_5_SPA.DAL.EF;
using ASP.NET_MVC_5_SPA.DAL.Entities;
using ASP.NET_MVC_5_SPA.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NET_MVC_5_SPA.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private InfoUserContext db = new InfoUserContext();
        private InfoUserEFRepository infoUserRepository;

        public InfoUserEFRepository InfoUsers
        {
            get
            {
                if (infoUserRepository == null)
                {
                    infoUserRepository = new InfoUserEFRepository(db);
                }
                return infoUserRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        #region disposed
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}