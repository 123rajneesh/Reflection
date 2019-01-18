using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6ClassLibraryFluentAPI
{
   public abstract class BaseEntity
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public bool IsActive { get; set; }
    }
}
