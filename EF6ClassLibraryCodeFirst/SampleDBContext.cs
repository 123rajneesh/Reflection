using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6ClassLibraryCodeFirst
{
    public class SampleDBContext : DbContext
    {

        public SampleDBContext() : base("name=SampleDb-EF6CodeFirst")
        {
            Database.SetInitializer(new SampleDBInitializer());
        }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Blog> Blogs { get; set; }
    }
}
