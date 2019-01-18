namespace EF6ClassLibraryFluentAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Removeteacher : DbMigration
    {
        public override void Up()
        {
            DropTable("Admin.Teachers");
        }
        
        public override void Down()
        {
            CreateTable(
                "Admin.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DoB = c.String(),
                        Height = c.String(),
                        Weight = c.String(),
                        BloodGroup = c.String(),
                        Photo = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
