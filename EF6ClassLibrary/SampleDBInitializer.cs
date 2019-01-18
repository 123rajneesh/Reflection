using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6ClassLibrary
{
   public class SampleDBInitializer : CreateDatabaseIfNotExists<SampleDBContext>
    {
        protected override void Seed(SampleDBContext context)
        {
            IList<Employee> employee = new List<Employee>();

            employee.Add(new Employee() { EmployeeName = "Ravi", Department = "IT" });
            employee.Add(new Employee() { EmployeeName = "Tom", Department = "IT" });
            employee.Add(new Employee() { EmployeeName = "Rick", Department = "HR" });
            employee.Add(new Employee() { EmployeeName = "Sam", Department = "Cloud" });
            context.Employee.AddRange(employee);

            base.Seed(context);
        }
    }
}
