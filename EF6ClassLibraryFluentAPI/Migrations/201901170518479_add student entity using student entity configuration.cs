namespace EF6ClassLibraryFluentAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addstudententityusingstudententityconfiguration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Admin.StudentInfo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Photo = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Admin.StudentDetail",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        DataOfBirth = c.String(),
                        Height = c.String(),
                        Weight = c.String(),
                        BloodNote = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Admin.StudentInfo", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Admin.StudentDetail", "Id", "Admin.StudentInfo");
            DropIndex("Admin.StudentDetail", new[] { "Id" });
            DropTable("Admin.StudentDetail");
            DropTable("Admin.StudentInfo");
        }
    }
}
