using ASP.NET_MVC_5_SPA.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NET_MVC_5_SPA.DAL.EF
{
    public class InfoUserContextInitializer : CreateDatabaseIfNotExists<InfoUserContext>
    {
        protected override void Seed(InfoUserContext db)
        {
            var userList = new List<InfoUser>()
            {
                new InfoUser() { Number=1, Date=new DateTime(2016,11,15), Company="Art", FirstName = "Иван", SecondName="Иванов", LastName="Иванович", Email="ivan@mail.com", Position="Операток ПК" },
                new InfoUser() { Number=2, Date=new DateTime(2016,11,14), Company="Diz", FirstName = "Петр", SecondName="Петров", LastName="Петрович", Email="petr@mail.com", Position="Менеджер" },
                new InfoUser() { Number=3, Date=new DateTime(2016,11,13), Company="Moz", FirstName = "Сергей", SecondName="Сергеев", LastName="Сергеевич", Email="sergey@mail.com", Position="Главный бухгалтер" }
            };

            userList.ForEach(s => db.InfoUsers.Add(s));
            db.SaveChanges();
        }
    }
}