using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6ClassLibraryFluentAPI
{
    public class Book : DomainEntity<int>
    {
        public int BookID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

    }
}
