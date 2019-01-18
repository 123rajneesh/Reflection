namespace EF6ClassLibraryFluentAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mapcolumnandtabletoteacher : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "Admin.Teachers", newName: "TeacherDeatil");
        }
        
        public override void Down()
        {
            RenameTable(name: "Admin.TeacherDeatil", newName: "Teachers");
        }
    }
}
