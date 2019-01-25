namespace EF6ClassLibraryFluentAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataannotaionaddedschemastoBlogentity11 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "Admin.StudentInfo", name: "Id", newName: "StudentInfoId");
        }
        
        public override void Down()
        {
            RenameColumn(table: "Admin.StudentInfo", name: "StudentInfoId", newName: "Id");
        }
    }
}
