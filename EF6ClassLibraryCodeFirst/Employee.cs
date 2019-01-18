using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6ClassLibraryCodeFirst
{
    
    public class Employee
    {
       
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public string Department { get; set; }
        public bool IsActive { get; set; }
   
    }
}
