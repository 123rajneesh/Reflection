namespace EF6ClassLibraryFluentAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBookEntityWithmultipleinheritance : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.StudentInfo", newName: "Store");
            RenameTable(name: "Admin.TeacherDeatil", newName: "Teachers");
            CreateTable(
                "Admin.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Type = c.String(),
                        Price = c.String(),
                        Author = c.String(),
                        RelaseDate = c.String(),
                        Publication = c.String(),
                        CreatedBy = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
                        BloodGroup = c.String(),
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
            DropTable("Admin.Books");
            RenameTable(name: "Admin.Teachers", newName: "TeacherDeatil");
            RenameTable(name: "dbo.Store", newName: "StudentInfo");
        }
    }
}
