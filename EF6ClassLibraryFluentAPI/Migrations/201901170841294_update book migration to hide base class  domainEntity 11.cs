namespace EF6ClassLibraryFluentAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatebookmigrationtohidebaseclassdomainEntity11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("Admin.Books", "BookID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("Admin.Books", "BookID");
        }
    }
}
