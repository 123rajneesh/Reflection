namespace EF6ClassLibraryFluentAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCVVfromTeacherEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("Admin.Teachers", "CVV", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("Admin.Teachers", "CVV");
        }
    }
}
