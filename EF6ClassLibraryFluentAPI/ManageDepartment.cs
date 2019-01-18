using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6ClassLibraryFluentAPI
{
    public class ManageDepartment
    {
        public static void AddDepartment(Department department)
        {
            using (var context = new SampleDBContext())
            {
                //context.Department.Add(department);
                //context.SaveChanges();
            }
        }
        public static Department DepartmentExist(Department department)
        {
            using (var ctx = new SampleDBContext())
            {
                //var id = from d
                //         in ctx.Department
                //         where
                //            d.Name == department.Name                          
                //         select d;
                //return id.FirstOrDefault();

                return new Department { Id = 1, Name = "HRD", IsActive = true };
            }
        }
    }
}
