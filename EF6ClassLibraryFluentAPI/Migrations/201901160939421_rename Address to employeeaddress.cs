namespace EF6ClassLibraryFluentAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renameAddresstoemployeeaddress : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "Admin.Addresses", newName: "EmployeeAddress");
            MoveTable(name: "Admin.EmployeeAddress", newSchema: "dbo");
        }
        
        public override void Down()
        {
            MoveTable(name: "dbo.EmployeeAddress", newSchema: "Admin");
            RenameTable(name: "Admin.EmployeeAddress", newName: "Addresses");
        }
    }
}
