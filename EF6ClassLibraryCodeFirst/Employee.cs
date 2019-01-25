using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6ClassLibraryCodeFirst
{
    [Table("EmployeeInfo")]
    public class Employee
    {       
        public int Id { get; set; }
        [Column("Name", TypeName = "ntext")]    
        [NotMapped]
        public string EmployeeName { get; set; }                
        public string Department { get; set; }
        public bool IsActive { get; set; }
   
    }
}
