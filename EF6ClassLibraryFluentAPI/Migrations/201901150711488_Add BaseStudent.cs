namespace EF6ClassLibraryFluentAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBaseStudent : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "Admin.StudentInfo", newName: "BaseStudent");
            DropForeignKey("Admin.StudentDetail", "Id", "Admin.StudentInfo");
            DropIndex("Admin.StudentDetail", new[] { "Id" });
            AddColumn("Admin.BaseStudent", "DataOfBirth", c => c.String());
            AddColumn("Admin.BaseStudent", "Height", c => c.String());
            AddColumn("Admin.BaseStudent", "Weight", c => c.String());
            AddColumn("Admin.BaseStudent", "BloodGroup", c => c.String());
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
            
            DropColumn("Admin.BaseStudent", "BloodGroup");
            DropColumn("Admin.BaseStudent", "Weight");
            DropColumn("Admin.BaseStudent", "Height");
            DropColumn("Admin.BaseStudent", "DataOfBirth");
            CreateIndex("Admin.StudentDetail", "Id");
            AddForeignKey("Admin.StudentDetail", "Id", "Admin.StudentInfo", "Id");
            RenameTable(name: "Admin.BaseStudent", newName: "StudentInfo");
        }
    }
}
