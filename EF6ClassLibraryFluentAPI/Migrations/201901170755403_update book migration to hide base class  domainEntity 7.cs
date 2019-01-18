namespace EF6ClassLibraryFluentAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatebookmigrationtohidebaseclassdomainEntity7 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "Admin.Book", newName: "Books");
        }
        
        public override void Down()
        {
            RenameTable(name: "Admin.Books", newName: "Book");
        }
    }
}
