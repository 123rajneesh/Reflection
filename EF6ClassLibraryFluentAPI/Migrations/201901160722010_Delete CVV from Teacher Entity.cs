namespace EF6ClassLibraryFluentAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteCVVfromTeacherEntity : DbMigration
    {
        public override void Up()
        {
            DropColumn("Admin.Teachers", "CVV");
        }
        
        public override void Down()
        {
            AddColumn("Admin.Teachers", "CVV", c => c.String());
        }
    }
}
