namespace EF6ClassLibraryFluentAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatebookmigrationtohidebaseclassdomainEntity10 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Admin.Books",
                c => new
                {
                    Price = c.String(nullable: false, maxLength: 128),
                    Name = c.String(),
                    Type = c.String()                       
                    })
                .PrimaryKey(t => t.Price);
            
        }
        
        public override void Down()
        {
            DropTable("Admin.Books");
        }
    }
}
