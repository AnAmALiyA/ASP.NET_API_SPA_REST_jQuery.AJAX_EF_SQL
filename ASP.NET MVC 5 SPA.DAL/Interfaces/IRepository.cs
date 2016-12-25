using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NET_MVC_5_SPA.DAL.Interfaces
{    
    interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetId(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}
