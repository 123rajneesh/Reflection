namespace EF6ClassLibraryFluentAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveStudent : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("Admin.StudentDetail", "Id", "Admin.StudentInfo");
            DropIndex("Admin.StudentDetail", new[] { "Id" });
            DropTable("Admin.StudentInfo");
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
                        BloodNote = c.String(),
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
            
            CreateIndex("Admin.StudentDetail", "Id");
            AddForeignKey("Admin.StudentDetail", "Id", "Admin.StudentInfo", "Id");
        }
    }
}
