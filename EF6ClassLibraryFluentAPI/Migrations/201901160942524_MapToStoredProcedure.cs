namespace EF6ClassLibraryFluentAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MapToStoredProcedure : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure(
                "Admin.Address_Insert",
                p => new
                    {
                        City = p.String(),
                        Country = p.String(),
                        Street = p.String(),
                        ZipCode = p.String(),
                    },
                body:
                    @"INSERT [dbo].[EmployeeAddress]([City], [Country], [Street], [ZipCode])
                      VALUES (@City, @Country, @Street, @ZipCode)
                      
                      DECLARE @Id int
                      SELECT @Id = [Id]
                      FROM [dbo].[EmployeeAddress]
                      WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()
                      
                      SELECT t0.[Id]
                      FROM [dbo].[EmployeeAddress] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id"
            );
            
            CreateStoredProcedure(
                "Admin.Address_Update",
                p => new
                    {
                        Id = p.Int(),
                        City = p.String(),
                        Country = p.String(),
                        Street = p.String(),
                        ZipCode = p.String(),
                    },
                body:
                    @"UPDATE [dbo].[EmployeeAddress]
                      SET [City] = @City, [Country] = @Country, [Street] = @Street, [ZipCode] = @ZipCode
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "Admin.Address_Delete",
                p => new
                    {
                        Id = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[EmployeeAddress]
                      WHERE ([Id] = @Id)"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("Admin.Address_Delete");
            DropStoredProcedure("Admin.Address_Update");
            DropStoredProcedure("Admin.Address_Insert");
        }
    }
}
