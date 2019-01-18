namespace EF6ClassLibraryFluentAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatemigration16 : DbMigration
    {
        public override void Up()
        {
            DropColumn("Admin.Books", "Price");
        }
        
        public override void Down()
        {
            AddColumn("Admin.Books", "Price", c => c.String());
        }
    }
}
