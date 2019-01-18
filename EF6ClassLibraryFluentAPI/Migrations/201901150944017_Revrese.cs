namespace EF6ClassLibraryFluentAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Revrese : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "Admin.BaseStudent", newName: "StudentInfo");
            CreateTable(
                "Admin.StudentDetail",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        DataOfBirth = c.String(),
                        Height = c.String(),
                        Weight = c.String(),
                        BloodGroup = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Admin.StudentInfo", t => t.Id)
                .Index(t => t.Id);
            
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
            
            DropColumn("Admin.StudentInfo", "DataOfBirth");
            DropColumn("Admin.StudentInfo", "Height");
            DropColumn("Admin.StudentInfo", "Weight");
            DropColumn("Admin.StudentInfo", "BloodGroup");
            DropColumn("Admin.Teachers", "Name");
            DropColumn("Admin.Teachers", "Height");
            DropColumn("Admin.Teachers", "Weight");
            DropColumn("Admin.Teachers", "BloodGroup");
            DropColumn("Admin.Teachers", "Photo");
            DropColumn("Admin.Teachers", "IsActive");
        }
        
        public override void Down()
        {
            AddColumn("Admin.Teachers", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("Admin.Teachers", "Photo", c => c.String());
            AddColumn("Admin.Teachers", "BloodGroup", c => c.String());
            AddColumn("Admin.Teachers", "Weight", c => c.String());
            AddColumn("Admin.Teachers", "Height", c => c.String());
            AddColumn("Admin.Teachers", "Name", c => c.String());
            AddColumn("Admin.StudentInfo", "BloodGroup", c => c.String());
            AddColumn("Admin.StudentInfo", "Weight", c => c.String());
            AddColumn("Admin.StudentInfo", "Height", c => c.String());
            AddColumn("Admin.StudentInfo", "DataOfBirth", c => c.String());
            DropForeignKey("Admin.StudentDetail", "Id", "Admin.StudentInfo");
            DropIndex("Admin.StudentDetail", new[] { "Id" });
            DropTable("Admin.Teacher1");
            DropTable("Admin.StudentDetail");
            RenameTable(name: "Admin.StudentInfo", newName: "BaseStudent");
        }
    }
}
