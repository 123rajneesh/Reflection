namespace EF6ClassLibraryFluentAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renamebooktobookdetail : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Book", newName: "BookDetail");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.BookDetail", newName: "Book");
        }
    }
}
