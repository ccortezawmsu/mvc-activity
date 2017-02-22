using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Again.Dal
{
    public class DataBaseContext: DbContext 
    {
       
        public DataBaseContext()
            : base("DefaultConnection")
        {          
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Education> Educations {get; set;}
    }
}
