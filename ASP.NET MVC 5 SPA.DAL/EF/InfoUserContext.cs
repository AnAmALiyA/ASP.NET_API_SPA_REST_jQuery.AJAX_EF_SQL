using ASP.NET_MVC_5_SPA.DAL.Entities;
using ASP.NET_MVC_5_SPA.DAL.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NET_MVC_5_SPA.DAL.EF
{
    public class InfoUserContext : DbContext
    {
        public InfoUserContext() : base("DbConnectionDatabaseSPA")
        { }

        public DbSet<InfoUser> InfoUsers { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {         
            modelBuilder.Configurations.Add(new InfoUserConfig());
            base.OnModelCreating(modelBuilder);
        }
    }
}