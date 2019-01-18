using EFCodeFirst = EF6ClassLibrary;
using EFCodeFirstFluentAPI = EF6ClassLibraryFluentAPI;
using System;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Reflection;

namespace EF6CodeFirstDemo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //RunCodeFirst();
            RunFluentAPICodeFirst();
            Console.ReadLine();
        }

        private static void RunFluentAPICodeFirst()
        {
            var getEmployee = EFCodeFirstFluentAPI.ManageEmployee.Get();

            var employee = new EFCodeFirstFluentAPI.Employee() { EmployeeName = "Ravi", Department = "IT",IsActive=true };

            var me = EFCodeFirstFluentAPI.ManageEmployee.EmployeeExist(employee);
            if ( me== null)
            {
                EFCodeFirstFluentAPI.ManageEmployee.AddEmployee(employee);
                Console.WriteLine("Employee added by FluentAPI.");
            }

            //Add Department
            var department = new EFCodeFirstFluentAPI.Department() { Id = 23, Name = "IT", IsActive = true };
            var md = EFCodeFirstFluentAPI.ManageDepartment.DepartmentExist(department);
            if (md == null)
            {
                EFCodeFirstFluentAPI.ManageDepartment.AddDepartment(department);
                Console.WriteLine("Department added by FluentAPI");
            }
        }

        private static void RunCodeFirst()
        {
          
               //Add Employee
               var employee = new EFCodeFirst.Employee() { EmployeeName = "Ravi", Department = "IT" };
            var me = EFCodeFirst.ManageEmployee.EmployeeExist(employee);
            if (me == null)
            {
                EFCodeFirst.ManageEmployee.AddEmployee(employee);
                Console.WriteLine("Employee added.");
            }


            //Add Department
            var department = new EFCodeFirst.Department() { Id = 23, Name = "IT" };
            var md = EFCodeFirst.ManageDepartment.DepartmentExist(department);
            if (md == null)
            {
                EFCodeFirst.ManageDepartment.AddDepartment(department);
                Console.WriteLine("Department added");
            }
        }

    }
}