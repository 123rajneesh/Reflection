namespace EF6ClassLibraryFluentAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Removebooktable : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.BookDetail");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.BookDetail",
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
            
        }
    }
}
