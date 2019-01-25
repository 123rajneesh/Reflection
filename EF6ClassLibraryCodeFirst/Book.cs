using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6ClassLibraryCodeFirst
{
    public class Book : BookDetail
    {
        public int BookID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

    }
}
