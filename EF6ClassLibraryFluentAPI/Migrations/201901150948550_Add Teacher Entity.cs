namespace EF6ClassLibraryFluentAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTeacherEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Admin.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DoB = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Admin.Teacher1",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Height = c.String(),
                        Weight = c.String(),
                        BloodGroup = c.String(),
                        Photo = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("Admin.Teacher1");
            DropTable("Admin.Teachers");
        }
    }
}
