using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6ClassLibraryCodeFirst
{
   // [Table("StudentInfo", Schema = "Admin")]
    public class Student
    {[Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [Column("DoB", TypeName = "DateTime2")]
        public DateTime? DataOfBirth { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        [NotMapped]
        public string BloodGroup { get; set; }
        [Column("Image", TypeName = "ntext")]
        public string Photo { get; set; }
        public bool IsActive { get; set; }
        public Blog Blog { get; set; }
    }
}
