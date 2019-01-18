namespace EF6ClassLibraryFluentAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FluentAPITableName : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Departments", newName: "Store");
            RenameTable(name: "dbo.Employees", newName: "User");
            MoveTable(name: "dbo.Store", newSchema: "Admin");
            MoveTable(name: "dbo.User", newSchema: "Admin");
        }
        
        public override void Down()
        {
            MoveTable(name: "Admin.User", newSchema: "dbo");
            MoveTable(name: "Admin.Store", newSchema: "dbo");
            RenameTable(name: "dbo.User", newName: "Employees");
            RenameTable(name: "dbo.Store", newName: "Departments");
        }
    }
}
