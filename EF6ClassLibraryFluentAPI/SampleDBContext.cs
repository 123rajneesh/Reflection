using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6ClassLibraryFluentAPI
{
    public class SampleDBContext : DbContext
    {

        public SampleDBContext() : base("name=SampleDbFluentAPI-EF6CodeFirst")
        {
            Database.SetInitializer<SampleDBContext>(new SampleDBInitializer());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Configure default schema
            modelBuilder.HasDefaultSchema("Admin");

            ////1.Map entity to table with defferent schemas
            //modelBuilder.Entity<Employee>().ToTable("User");

            //modelBuilder.Entity<Department>().ToTable("Store", "dbo");

            //modelBuilder.Entity<Book>().ToTable("BookDetail", "dbo");

            //modelBuilder.Entity<Address>().ToTable("EmployeeAddress", "dbo");

            //2.Map Single Entity to multiple table
            //_entityMappingConfigurations when we map entity properties to table's

            //modelBuilder.Entity<Student>().Map(m =>
            //{
            //    m.Properties(p => new { p.Id, p.Name, p.Photo, p.IsActive });
            //    m.ToTable("StudentInfo");
            //}).Map(m =>
            //{
            //m.Properties(p => new { p.Id, p.DataOfBirth, p.Height, p.Weight, p.BloodGroup });
            //    m.ToTable("StudentDetail");
            //    m.Property(p => p.BloodGroup).HasColumnName("BloodNote");                
            //});
            //3.Entity Table Mapped ColumnName
            // Result: 1.IsStructuralConfigurationOnly==true when ignore method implimented
            //         2.PrimitivePropertyConfigurations Count is not 0 when entity property is mapped as column name.-
            //modelBuilder.Entity<Teacher>().Ignore(i => i.CVV)
            //       .Property(p => p.DateOfBirth)
            //       .HasColumnName("DoB");


            ////4.Mapped Table with column name
            //modelBuilder.Entity<Teacher>().ToTable("TeacherDetail")
            //       .Property(p => p.Name)
            //       .HasColumnName("FullName");

            //MapToStoredProcedures creates defult CUD operations for entity
            //modelBuilder.Entity<Address>()
            //    .MapToStoredProcedures();

            modelBuilder.Conventions.Add<PluralizingTableNameConvention>();


            modelBuilder.Configurations.Add(new StudentEntityConfiguration());

            modelBuilder.Configurations.Add(new TeacherEntityConfiguration());

            modelBuilder.Configurations.Add(new EmployeeEntityConfiguration());

            modelBuilder.Configurations.Add(new AddressEntityConfiguearion());

            modelBuilder.Configurations.Add(new DepartmentEntityConfiguration());

            //This is TPH mapping as there is a single table for the hierarchy.Table per Hierarchy (TPH): This approach suggests one table for the entire class inheritance hierarchy
            modelBuilder.Configurations.Add(new BookEntityConfiguration());
            
            //if you call ToTable on both classe then each type will be mapped to its own table, also known as TPT since each type has its own table.Table per Type (TPT) This approach suggests a separate table for each domain class
            modelBuilder.Types<Book>()
               .Configure(c => c.ToTable(c.ClrType.Name));

        }
    }
}
