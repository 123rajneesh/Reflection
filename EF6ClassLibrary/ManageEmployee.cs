using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6ClassLibrary
{
    public class ManageEmployee
    {
        public static IList<Employee> AddDemoEmployee()
        {
            IList<Employee> employee = new List<Employee>();

            employee.Add(new Employee() { EmployeeName = "Ravi", Department = "IT" });
            employee.Add(new Employee() { EmployeeName = "Tom", Department = "IT" });
            employee.Add(new Employee() { EmployeeName = "Rick", Department = "HR" });
            employee.Add(new Employee() { EmployeeName = "Sam", Department = "Cloud" });

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
    }
}
