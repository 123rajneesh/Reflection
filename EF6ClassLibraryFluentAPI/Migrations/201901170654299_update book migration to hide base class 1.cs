namespace EF6ClassLibraryFluentAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatebookmigrationtohidebaseclass1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "Admin.BookCatalog", name: "Writer", newName: "Author");
            DropPrimaryKey("Admin.BookCatalog");
            AlterColumn("Admin.BookCatalog", "Id", c => c.Int(nullable: false));
            AlterColumn("Admin.BookCatalog", "Price", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("Admin.BookCatalog", "Price");
        }
        
        public override void Down()
        {
            DropPrimaryKey("Admin.BookCatalog");
            AlterColumn("Admin.BookCatalog", "Price", c => c.String());
            AlterColumn("Admin.BookCatalog", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("Admin.BookCatalog", "Id");
            RenameColumn(table: "Admin.BookCatalog", name: "Author", newName: "Writer");
        }
    }
}
