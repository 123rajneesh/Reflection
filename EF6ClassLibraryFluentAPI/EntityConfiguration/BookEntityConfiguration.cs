using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6ClassLibraryFluentAPI
{
    public class BookEntityConfiguration :EntityTypeConfiguration<Book>
    {
        public BookEntityConfiguration()
        {
            //this.ToTable("BookDetail", "dbo");

            //Case 1: To hide the base class property while generation columns


           
            this.HasKey<string>((Book e) => e.Name);
            this.ToTable("Books")
                .Property((Book e) => e.Name)
                .HasColumnName("Name")
                .HasDatabaseGeneratedOption(new DatabaseGeneratedOption?(DatabaseGeneratedOption.None));

            this.HasKey<string>((Book e) => e.Type);
            this.ToTable("Books")
                .Property((Book e) => e.Type)
                .HasColumnName("Type")
                .HasDatabaseGeneratedOption(new DatabaseGeneratedOption?(DatabaseGeneratedOption.None));

            this.HasKey<int>((Book e) => e.BookID);
            this.ToTable("Books")
                .Property((Book e) => e.BookID)
                .HasColumnName("BookID")
                .HasDatabaseGeneratedOption(new DatabaseGeneratedOption?(DatabaseGeneratedOption.None));

        }
    }
}
