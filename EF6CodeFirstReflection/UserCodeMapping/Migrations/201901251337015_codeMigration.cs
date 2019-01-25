namespace System.Data.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class codeMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        City = c.String(),
                        Country = c.String(),
                        Street = c.String(),
                        ZipCode = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        Title = c.String(nullable: false, maxLength: 128),
                        BloggerName1 = c.String(),
                        BlogType = c.String(),
                        CreatedDated = c.DateTime(),
                        BloggerName = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Title);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookID = c.Int(nullable: false),
                        Name = c.String(),
                        Type = c.String(),
                        Author = c.String(),
                        RelaseDate = c.String(),
                        Publication = c.String(),
                        CreatedBy = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EmployeeInfo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Department = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DoB = c.DateTime(precision: 7, storeType: "datetime2"),
                        Height = c.String(),
                        Weight = c.String(),
                        Image = c.String(storeType: "ntext"),
                        IsActive = c.Boolean(nullable: false),
                        Blog_Title = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Blogs", t => t.Blog_Title)
                .Index(t => t.Blog_Title);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DateOfBirth = c.String(),
                        Height = c.String(),
                        Weight = c.String(),
                        BloodGroup = c.String(),
                        Photo = c.String(),
                        CVV = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "Blog_Title", "dbo.Blogs");
            DropIndex("dbo.Students", new[] { "Blog_Title" });
            DropTable("dbo.Teachers");
            DropTable("dbo.Students");
            DropTable("dbo.EmployeeInfo");
            DropTable("dbo.Departments");
            DropTable("dbo.Books");
            DropTable("dbo.Blogs");
            DropTable("dbo.Addresses");
        }
    }
}
