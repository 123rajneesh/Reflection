using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6ClassLibraryFluentAPI
{
    public class ManageEmployee
    {
        public static IList<Employee> AddDemoEmployee()
        {
            IList<Employee> employee = new List<Employee>
            {
                new Employee() { EmployeeName = "Ravi", Department = "IT" },
                new Employee() { EmployeeName = "Tom", Department = "IT" },
                new Employee() { EmployeeName = "Rick", Department = "HR" },
                new Employee() { EmployeeName = "Sam", Department = "Cloud" }
            };

            return employee;
        }
        public static void AddEmployee(Employee employee)
        {
            using (var ctx = new SampleDBContext())
            {
                ctx.Employee.Add(employee);
                ctx.SaveChanges();
            }
        }
        public static Employee EmployeeExist(Employee employee)
        {

            using (var ctx = new SampleDBContext())
            {
                var id = from e
                         in ctx.Employee
                         where
                            e.EmployeeName == employee.EmployeeName
                            && e.Department == employee.Department
                         select e;
                return id.FirstOrDefault();
            }

        }

        public static List<Employee> Get()
        {
            using (var ctx = new SampleDBContext())
            {
                var e = from ent in ctx.Employee select ent;
                return e.ToList();
            }
        }
    }
}
