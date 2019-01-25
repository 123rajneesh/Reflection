using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6ClassLibraryCodeFirst
{
    //Derived class
    public class Blog : BlogInfo
    {
        [Key]
        public string Title { get; set; }
        public string BloggerName { get; set; }
    }
    //Complex type
    public class BlogDetails
    {
        [Column("CreatedDated")]
        public DateTime? DateCreated { get; set; }
        [Column("BloggerName")]
        [MaxLength(20)]
        public string BloggerName { get; set; }
    }
    //Base class with complex type
    public class BlogInfo
    {
        public string BlogType { get; set; }
        [Column("BloggerName")]
        [MaxLength(20)]
        public BlogDetails Description { get; set; }
    }
}
