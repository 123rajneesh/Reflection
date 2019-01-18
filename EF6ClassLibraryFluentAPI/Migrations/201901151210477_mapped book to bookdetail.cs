namespace EF6ClassLibraryFluentAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mappedbooktobookdetail : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "Admin.Books", newName: "Book");
            MoveTable(name: "Admin.Book", newSchema: "dbo");
        }
        
        public override void Down()
        {
            MoveTable(name: "dbo.Book", newSchema: "Admin");
            RenameTable(name: "Admin.Book", newName: "Books");
        }
    }
}
