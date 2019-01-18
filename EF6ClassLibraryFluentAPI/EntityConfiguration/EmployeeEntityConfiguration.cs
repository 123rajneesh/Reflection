using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6ClassLibraryFluentAPI
{

    public class EmployeeEntityConfiguration : EntityTypeConfiguration<Employee>
    {
        public EmployeeEntityConfiguration()
        {
            //1.Map entity to table with defferent schemas
            this.ToTable("User");

        }
    }
}
