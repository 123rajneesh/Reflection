namespace EF6ClassLibraryFluentAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class departmentdbsetremove3243243 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.StudentDetail", newName: "StudentInfo");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.StudentInfo", newName: "StudentDetail");
        }
    }
}
