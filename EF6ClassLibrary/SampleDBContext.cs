using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6ClassLibrary
{
    public class SampleDBContext: DbContext
    {

        public SampleDBContext() : base("name=SampleDb-EF6CodeFirst")
        {
            Database.SetInitializer<SampleDBContext>(new SampleDBInitializer());
        }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Department> Department { get; set; }
        public Test Test { get; set; }
    }
}
