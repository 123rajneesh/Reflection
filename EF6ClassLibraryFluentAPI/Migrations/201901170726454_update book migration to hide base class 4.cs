namespace EF6ClassLibraryFluentAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatebookmigrationtohidebaseclass4 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "Admin.BookCatalog", newName: "Book");
        }
        
        public override void Down()
        {
            RenameTable(name: "Admin.Book", newName: "BookCatalog");
        }
    }
}
