using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PracticaExamen.Models
{
    public class DataContext:DbContext
    {
        public DataContext():base("DefaultConnection")
        {
            
        }

        public System.Data.Entity.DbSet<PracticaExamen.Models.Valverde> Valverdes { get; set; }
    }
}