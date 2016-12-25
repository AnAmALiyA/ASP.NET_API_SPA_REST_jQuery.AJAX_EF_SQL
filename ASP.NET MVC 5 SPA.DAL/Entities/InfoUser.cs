//#define annotation
#define FluentAPI
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NET_MVC_5_SPA.DAL.Entities
{
    public class InfoUser
    {
        public virtual int Id { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual int Number { get; set; }
        public virtual string Company { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string SecondName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Position { get; set; }
        public virtual string Email { get; set; }
    }
}