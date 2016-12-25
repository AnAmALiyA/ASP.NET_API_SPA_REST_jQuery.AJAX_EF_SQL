using ASP.NET_MVC_5_SPA.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NET_MVC_5_SPA.DAL.Infrastructure.Mapping
{
    public class InfoUserConfig: EntityTypeConfiguration<InfoUser>
    {
        public InfoUserConfig()
        {
            // Primary Key
            this.HasKey(id => id.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("InfoUsers");
            this.Property(id => id.Id).HasColumnName("Id");
            this.Property(date => date.Date).HasColumnName("Date").IsRequired().HasColumnType("datetime2");
            this.Property(number => number.Number).HasColumnName("Number").IsRequired();
            this.Property(company => company.Company).HasColumnName("Company").HasMaxLength(50).IsRequired();
            this.Property(firstName => firstName.FirstName).HasColumnName("FirstName").IsRequired().HasMaxLength(20);
            this.Property(secondName => secondName.SecondName).HasColumnName("SecondName").IsRequired().HasMaxLength(20);
            this.Property(lastName => lastName.LastName).HasColumnName("LastName").IsRequired().HasMaxLength(20);
            this.Property(positione => positione.Position).HasColumnName("Position").HasMaxLength(30).IsRequired();
            this.Property(email => email.Email).HasColumnName("Email").HasMaxLength(30).IsRequired();
        }
    }
}