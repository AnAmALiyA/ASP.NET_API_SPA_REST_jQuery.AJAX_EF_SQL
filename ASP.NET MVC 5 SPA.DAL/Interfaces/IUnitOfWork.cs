using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NET_MVC_5_SPA.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
    }
}
