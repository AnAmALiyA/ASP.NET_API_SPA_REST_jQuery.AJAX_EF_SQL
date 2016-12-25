using ASP.NET_MVC_5_SPA.DAL.EF;
using ASP.NET_MVC_5_SPA.DAL.Entities;
using ASP.NET_MVC_5_SPA.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NET_MVC_5_SPA.DAL.Repositories
{
    public class InfoUserEFRepository : IRepository<InfoUser>
    {
        private InfoUserContext db;

        public InfoUserEFRepository(InfoUserContext context)
        {
            db = context;
        }

        public IEnumerable<InfoUser> GetAll()
        {
            return db.InfoUsers;
        }

        public InfoUser GetId(int id)
        {
            return db.InfoUsers.Find(id);
        }

        public void Create(InfoUser infoUser)
        {
            db.InfoUsers.Add(infoUser);
        }

        public void Update(InfoUser infoUser)
        {            
            InfoUser infuse = db.InfoUsers.Find(infoUser.Id);
            if (infuse!=null)
            {
                //db.InfoUsers.Attach(infoUser);  
                //db.Entry(infoUser).State = EntityState.Modified;

                // or

                infuse.Id = infoUser.Id;
                infuse.Date = infoUser.Date;
                infuse.Number = infoUser.Number;
                infuse.Company = infoUser.Company;
                infuse.FirstName = infoUser.FirstName;
                infuse.SecondName = infoUser.SecondName;
                infuse.LastName = infoUser.LastName;
                infuse.Position = infoUser.Position;
                infuse.Email = infoUser.Email;
            }
        }

        public void Delete(int id)
        {
            InfoUser order = db.InfoUsers.Find(id);
            if (order != null)
                db.InfoUsers.Remove(order);
        }        
    }
}