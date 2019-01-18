namespace EF6ClassLibraryFluentAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class departmentmultiple : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Store", newName: "StudentDetail");
            RenameTable(name: "Admin.StudentInfo", newName: "Students");
            DropForeignKey("Admin.StudentDetail", "Id", "Admin.StudentInfo");
            DropIndex("Admin.StudentDetail", new[] { "Id" });
            AddColumn("Admin.Students", "DataOfBirth", c => c.String());
            AddColumn("Admin.Students", "Height", c => c.String());
            AddColumn("Admin.Students", "Weight", c => c.String());
            AddColumn("Admin.Students", "BloodGroup", c => c.String());
            DropTable("Admin.StudentDetail");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.Id);
            
            DropColumn("Admin.Students", "BloodGroup");
            DropColumn("Admin.Students", "Weight");
            DropColumn("Admin.Students", "Height");
            DropColumn("Admin.Students", "DataOfBirth");
            CreateIndex("Admin.StudentDetail", "Id");
            AddForeignKey("Admin.StudentDetail", "Id", "Admin.StudentInfo", "Id");
            RenameTable(name: "Admin.Students", newName: "StudentInfo");
            RenameTable(name: "dbo.StudentDetail", newName: "Store");
        }
    }
}
