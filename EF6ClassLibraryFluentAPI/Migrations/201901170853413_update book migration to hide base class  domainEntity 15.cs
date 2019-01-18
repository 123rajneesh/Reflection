namespace EF6ClassLibraryFluentAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatebookmigrationtohidebaseclassdomainEntity15 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("Admin.Books");
            AlterColumn("Admin.Books", "Price", c => c.String());
            AddPrimaryKey("Admin.Books", "BookID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("Admin.Books");
            AlterColumn("Admin.Books", "Price", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("Admin.Books", "Price");
        }
    }
}
