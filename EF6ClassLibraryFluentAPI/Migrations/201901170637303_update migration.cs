namespace EF6ClassLibraryFluentAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatemigration : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "Admin.Employees", newName: "User");
        }
        
        public override void Down()
        {
            RenameTable(name: "Admin.User", newName: "Employees");
        }
    }
}
