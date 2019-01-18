namespace EF6ClassLibraryFluentAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatebookmigrationtohidebaseclass5domainEntity : DbMigration
    {
        public override void Up()
        {
            DropColumn("Admin.Book", "Author");
            DropColumn("Admin.Book", "RelaseDate");
            DropColumn("Admin.Book", "Publication");
            DropColumn("Admin.Book", "CreatedBy");
            DropColumn("Admin.Book", "IsActive");
        }
        
        public override void Down()
        {
            AddColumn("Admin.Book", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("Admin.Book", "CreatedBy", c => c.String());
            AddColumn("Admin.Book", "Publication", c => c.String());
            AddColumn("Admin.Book", "RelaseDate", c => c.String());
            AddColumn("Admin.Book", "Author", c => c.String());
        }
    }
}
