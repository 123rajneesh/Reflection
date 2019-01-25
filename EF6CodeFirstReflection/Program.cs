using CrossCode.BLL.Domain.DBUsageStructure;
//using EF6ClassLibraryCodeFirst;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.MappingViews;
using System.Data.Entity.Migrations;
using System.Data.Entity.Migrations.Design;
using System.Data.Entity.Migrations.Infrastructure;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace EF6CodeFirstReflection
{
    public class Program
    {
        static string rootPath = @"C:\Users\rajneesh.kumar\source\repos\EF6-Code-First-Demo-master\EF6CodeFirstReflection\UserCodeMapping";
        public static void Main(string[] args)
        {
            Console.WriteLine("Press 1 for CodeFirst Metadata");

            var assemblyPath = Console.ReadLine();

            bool isIntiger = int.TryParse(assemblyPath, out int integervalue);

            if (isIntiger)
            {

                switch (integervalue)
                {

                    case 1:

                        gettypfromassebmly();
                        //GetAllMigration();

                        //var dbMappingDetails2 = CodeFirstRefelection.GetAttibutes(); ;

                        //var entitiesInDbSet = CodeFirstRefelection.GetEntitiesFromAssembly();

                        //var databaseInfo = CodeFirstRefelection.GetDatabaseDetail();

                       // var data = CodeFirstRefelection.GetEntityMappingMetadta();

                        break;

                    default:
                        Logger.Testing();

                        Console.WriteLine("Not found");

                        break;
                }
            }
            else
            {
                Console.WriteLine("Input type is not valid.");
            }
            Console.WriteLine("Completed.");

            Console.ReadLine();
        }

        /*
           public static string GetAllMigration()
        {


            var config = new DbMigrationsConfiguration<SampleDBContext> { AutomaticMigrationsEnabled = true };

            var migrator = new DbMigrator(config);

            //Get code migration//
            var scaffolder = new MigrationScaffolder(migrator.Configuration);

            ScaffoldedMigration migration = scaffolder.Scaffold("codeMigration");

            var migrationFile = System.IO.Path.Combine(rootPath, migration.Directory, migration.MigrationId);

            var userCodeFile = migrationFile + ".cs";

            File.WriteAllText(userCodeFile, migration.UserCode);

            //Get Db script//
            var scriptor = new MigratorScriptingDecorator(migrator);

            string script = scriptor.ScriptUpdate(sourceMigration: null, targetMigration: null);

            var SqlScriptFile = migrationFile + ".sql";

            File.WriteAllText(SqlScriptFile, script);

            //Get Edmx Document//

            var _currenModelProp = migrator.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance).Single(m => m.Name == "_currentModel");

            var _currenModelValueXDOC = (XDocument)_currenModelProp.GetValue(migrator);

            var edmxFile = migrationFile + ".xml";


            File.WriteAllText(edmxFile, _currenModelValueXDOC.ToString());

            return script;
        }
         */
         
        static void gettypfromassebmly()
        {
            var assemblyPath = @"C:\Users\rajneesh.kumar\source\repos\EF6-Code-First-Demo-master\EF6CodeFirstDemo\bin\Debug";

            var assemblyName = string.Format(@"{0}\{1}.{2}", assemblyPath, "EF6ClassLibraryCodeFirst", "dll");

            var assembly = Assembly.LoadFrom(assemblyName);

            var type = assembly.GetType("EF6ClassLibraryCodeFirst.SampleDBContext");
            
            Type genericClass = typeof(DbMigrationsConfiguration<>);

            //MakeGenericType is badly named
            Type constructedClass = genericClass.MakeGenericType(type);

            object created = Activator.CreateInstance(constructedClass);

            ////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////////////////


            var config = (DbMigrationsConfiguration)created;

            config.AutomaticMigrationsEnabled = true;

            var migrator = new DbMigrator(config);

            //Get code migration//
            var scaffolder = new MigrationScaffolder(migrator.Configuration);

            ScaffoldedMigration migration = scaffolder.Scaffold("codeMigration");

            var migrationFile = System.IO.Path.Combine(rootPath, migration.Directory, migration.MigrationId);

            var userCodeFile = migrationFile + ".cs";

            File.WriteAllText(userCodeFile, migration.UserCode);

            //Get Db script//
            var scriptor = new MigratorScriptingDecorator(migrator);

            string script = scriptor.ScriptUpdate(sourceMigration: null, targetMigration: null);

            var SqlScriptFile = migrationFile + ".sql";

            File.WriteAllText(SqlScriptFile, script);

            //Get Edmx Document//
            var _currenModelProp = migrator.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance).Single(m => m.Name == "_currentModel");

            var _currenModelValueXDOC = (XDocument)_currenModelProp.GetValue(migrator);

            var edmxFile = migrationFile + ".xml";

            File.WriteAllText(edmxFile, _currenModelValueXDOC.ToString());
        }

        

    }
}
