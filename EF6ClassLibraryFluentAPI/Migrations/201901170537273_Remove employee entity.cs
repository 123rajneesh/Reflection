namespace EF6ClassLibraryFluentAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Removeemployeeentity : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "Admin.User", newName: "Employees");
        }
        
        public override void Down()
        {
            RenameTable(name: "Admin.Employees", newName: "User");
        }
    }
}
