using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6ClassLibraryFluentAPI
{
    public class AddressEntityConfiguearion : EntityTypeConfiguration<Address>
    {
        public AddressEntityConfiguearion()
        {
            this.ToTable("EmployeeAddress", "dbo");
           

            //To Create Default CUD Stored procedure for the entity
            this.MapToStoredProcedures();
               
        }


    }
}
