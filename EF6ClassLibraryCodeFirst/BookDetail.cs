using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6ClassLibraryCodeFirst
{
    public abstract class BookDetail:BaseEntity
    {
        public string Author { get; set; }
        public string RelaseDate { get; set; }
        public string Publication { get; set; }
    }
}
