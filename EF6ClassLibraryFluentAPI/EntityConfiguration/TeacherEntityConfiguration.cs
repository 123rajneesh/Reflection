using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6ClassLibraryFluentAPI
{
    public class TeacherEntityConfiguration : EntityTypeConfiguration<Teacher>
    {
        public TeacherEntityConfiguration()
        {
            //3.Entity Table Mapped ColumnName
            // Result: 1.IsStructuralConfigurationOnly==true when ignore method implimented
            //         2.PrimitivePropertyConfigurations Count is not 0 when entity property is mapped as column name.-
            this.Ignore(i => i.CVV)
                   .Property(p => p.DateOfBirth)
                   .HasColumnName("DoB");


            ////4.Mapped Table with column name
            //this.ToTable("TeacherDetail")
            //       .Property(p => p.Name)
            //       .HasColumnName("FullName");
        }
    }
}
