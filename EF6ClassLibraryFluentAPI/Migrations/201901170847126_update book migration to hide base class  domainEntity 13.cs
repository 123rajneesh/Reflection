namespace EF6ClassLibraryFluentAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatebookmigrationtohidebaseclassdomainEntity13 : DbMigration
    {
        public override void Up()
        {
            DropTable("Admin.Books");
        }
        
        public override void Down()
        {
            CreateTable(
                "Admin.Books",
                c => new
                    {
                        Price = c.String(nullable: false, maxLength: 128),
                        BookID = c.Int(nullable: false),
                        Name = c.String(),
                        Type = c.String(),
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Price);
            
        }
    }
}
