using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6ClassLibraryFluentAPI
{
    public class DepartmentEntityConfiguration : EntityTypeConfiguration<Department>
    {
        public DepartmentEntityConfiguration()
        {
            this.ToTable("Store", "dbo");
        }
    }
}
