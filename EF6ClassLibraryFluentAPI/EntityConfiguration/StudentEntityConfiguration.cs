using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6ClassLibraryFluentAPI
{
    public class StudentEntityConfiguration : EntityTypeConfiguration<Student>
    {
        public StudentEntityConfiguration()
        {
            // Map Single Entity to multiple table
            //_entityMappingConfigurations when we map entity properties to table's
            //PrimitivePropertyConfigurations Count is not 0 when entity property is mapped as column name
            this.Map(m =>
            {
                m.Properties(p => new { p.Id, p.Name, p.Photo, p.IsActive });
                m.Property(p=>p.Id).HasColumnName("StudentInfoId");
                m.ToTable("StudentInfo");
            }).Map(m =>
            {
                m.Properties(p => new { p.Id, p.DataOfBirth, p.Height, p.Weight, p.BloodGroup });
                m.ToTable("StudentDetail");
                m.Property(p => p.BloodGroup).HasColumnName("BloodNote");
            });
        }
    }
}
