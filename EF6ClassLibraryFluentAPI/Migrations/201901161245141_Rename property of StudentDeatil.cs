namespace EF6ClassLibraryFluentAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamepropertyofStudentDeatil : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "Admin.StudentDetail", name: "BloodGroup", newName: "BloodNote");
        }
        
        public override void Down()
        {
            RenameColumn(table: "Admin.StudentDetail", name: "BloodNote", newName: "BloodGroup");
        }
    }
}
