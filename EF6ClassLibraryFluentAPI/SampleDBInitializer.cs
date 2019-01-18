using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6ClassLibraryFluentAPI
{
   public class SampleDBInitializer : CreateDatabaseIfNotExists<SampleDBContext>
    {
        protected override void Seed(SampleDBContext context)
        {
            //IList<Employee> employee = new List<Employee>
            //{
            //    new Employee() { EmployeeName = "Ravi", Department = "IT" },
            //    new Employee() { EmployeeName = "Tom", Department = "IT" },
            //    new Employee() { EmployeeName = "Rick", Department = "HR" },
            //    new Employee() { EmployeeName = "Sam", Department = "Cloud" }
            //};
            //context.Employee.AddRange(employee);

            //base.Seed(context);
        }
    }
}
