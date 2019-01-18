using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6ClassLibraryFluentAPI
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DataOfBirth { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string BloodGroup { get; set; }
        public string Photo { get; set; }
        public bool IsActive { get; set; }
    }
}
