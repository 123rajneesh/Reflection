using CrossCode.BLL.Domain.DBUsageStructure;
//using EF6ClassLibraryCodeFirst;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EF6CodeFirstReflection
{
    public class CodeFirstRefelection
    {
        //public static List<ORMMetadata> GetEntityMappingMetadta()
        //{
        //    SampleDBContext g = new SampleDBContext();

        //    Type type = typeof(SampleDBContext);

        //    var entityData = GetEntitywithProperties(type);

        //    return entityData;
        //}

        private static List<ORMMetadata> GetEntitywithProperties(Type type)
        {
            var contextruntimeproperties = type.GetRuntimeProperties();

            ORMMetadata ormMetadataEntity = null;
            List<ORMMetadata> entityList = new List<ORMMetadata>();
            foreach (var entity in contextruntimeproperties)
            {
                if (entity.PropertyType.Name == "DbSet`1")
                {
                    ormMetadataEntity = new ORMMetadata();

                    var entityProps = entity.PropertyType.GetGenericArguments();

                    ormMetadataEntity.EntiyFullName = entityProps[0].FullName;

                    ormMetadataEntity.EntityName = entityProps[0].Name;

                    foreach (var ep in entityProps)
                    {
                        var pi = ep.GetProperties();
                        foreach (var p in ep.GetProperties())
                        {
                            ormMetadataEntity.MemberOfClass.Add(new MemberOfClass { PropertyName = p.Name });
                        }
                    }
                    entityList.Add(ormMetadataEntity);
                }
            }
            return entityList;
        }
        private static Type[] LoadAssembly()
        {
            var assemblyPath = @"C:\Users\rajneesh.kumar\source\repos\EF6-Code-First-Demo-master\EF6CodeFirstDemo\bin\Debug";

            var assemblyName = string.Format(@"{0}\{1}.{2}", assemblyPath, "EF6ClassLibraryCodeFirst", "dll");

            Assembly projectAssembly = Assembly.LoadFile(assemblyName);

            var typeInAssembly = projectAssembly.GetTypes();

            return typeInAssembly;
        }
        /// <summary>
        /// Get all Types from laoded Assembly
        /// </summary>
        /// <param name="typeInAssembly"></param>
        public static List<ORMMetadata> GetEntitiesFromAssembly()
        {

            var typeInAssembly = LoadAssembly();

            var ormList = new List<ORMMetadata>();

            var contextTypefromAssembly = typeInAssembly.Where(t => t.BaseType.FullName == "System.Data.Entity.DbContext").Select(e => e).ToList();

            foreach (Type t in contextTypefromAssembly)
            {
                Console.WriteLine(" Type is {0} drived from {1}", t, t.BaseType);

                Console.WriteLine("Get Properties info of drived class");

                var prop = t.GetProperties();

                var mm = t.GetMethods();

                var DbModel = prop.Where(f => f.PropertyType.Name == "DbSet`1").Select(p => p).ToList();

                foreach (var model in DbModel)
                {

                    var typeInfo = model.PropertyType.GetGenericArguments();
                    string assembly = typeInfo[0].Assembly.GetName().Name;
                    string className = typeInfo[0].Name;

                    var propertyInfo = typeInfo[0].GetRuntimeProperties();

                    var orm = new ORMMetadata();
                    orm.AssemblyName = assembly;
                    orm.EntityName = className;
                    orm.EntiyFullName = typeInfo[0].FullName;
                    orm.Namespace = typeInfo[0].Namespace;


                    foreach (var pi in propertyInfo)
                    {
                        var moc = new MemberOfClass();
                        var propInfo = pi.Name;
                        moc.PropertyName = pi.Name;
                        orm.MemberOfClass.Add(moc);
                    }
                    ormList.Add(orm);
                }
            }

            return ormList;
        }
        /// <summary>
        /// Get code first mapped attibutes
        /// </summary>
        /// <returns></returns>
        public static List<DBMappingDetails2> GetAttibutes()
        {
            List<DBMappingDetails2> listDBMappingDetails2 = new List<DBMappingDetails2>();

            //Loading Dll from location
            var typeInAssembly = LoadAssembly();

            //Get class which is available drived from "System.Data.Entity.DbContext"
            var contextTypefromAssembly = typeInAssembly.Where(t => t.BaseType.FullName == "System.Data.Entity.DbContext").Select(e => e).First();

            //Get all properties of drived class
            var prop = contextTypefromAssembly.GetProperties();

            //Filter DbSet type properties 
            var DbModel = prop.Where(f => f.PropertyType.Name == "DbSet`1").Select(p => p).ToList();

            foreach (var model in DbModel)
            {
                //Get runtime properties
                var typeInfo = model.PropertyType.GetGenericArguments();

                //Get assembly name of type
                var assembly = typeInfo[0].Assembly.GetName().Name;

                //Get class name
                var className = typeInfo[0].Name;

                //Get Full anme including nampespace
                var EntiyFullName = typeInfo[0].FullName;

                //Get Namespace of class
                var Namespace = typeInfo[0].Namespace;


                foreach (var type in typeInAssembly)
                {
                    if (type.FullName == EntiyFullName)
                    {
                        var properties = type.GetProperties().Where(p => p.GetCustomAttributes().Count() > 0).Select(m => m).ToList();

                        //Get table attribute detail of class
                        var mappedTable = GetTableAttributes(type);

                        //Get mapped column of properties
                        var mappedColumn = GetColumnAttributes(properties);

                        if (mappedTable != null || mappedColumn.Count > 0)
                        {
                            var dbMappingDetails2 = new DBMappingDetails2();

                            IDBMapItem dbMapItem2 = new DBMapItem2();

                            dbMapItem2.MappedAssembly = assembly;

                            dbMapItem2.MappedClass = className;

                            dbMapItem2.MappedSchemaName = mappedTable?.Schema;

                            dbMapItem2.TblNameKey = mappedTable?.Name;

                            dbMapItem2.CollectionOFMappedColumnProperties = mappedColumn;

                            dbMappingDetails2.GenericORMmapDetails = new List<IDBMapItem>();

                            dbMappingDetails2.GenericORMmapDetails.Add(dbMapItem2);

                            listDBMappingDetails2.Add(dbMappingDetails2);
                        }

                    }
                }
            }
            return listDBMappingDetails2;
        }

        private static Dictionary<string, string> GetColumnAttributes(IEnumerable<PropertyInfo> properties)
        {
            var mappedColumnDict = new Dictionary<string, string>();
            // Get Custom Attribute of Column by filter custome attribute count
            foreach (var pr in properties)
            {

                var propName = pr.Name;

                //Get NotMapped Property
                IEnumerable<NotMappedAttribute> notMappedAttribute = pr.GetCustomAttributes<NotMappedAttribute>();

                if (notMappedAttribute.Count() > 0)
                {

                    foreach (var nmp in notMappedAttribute)
                    {
                        var nmpObj = nmp;
                    }
                }

                //Get columnName attribute
                IEnumerable<ColumnAttribute> columnAttribute = pr.GetCustomAttributes<ColumnAttribute>();

                if (columnAttribute.Count() > 0)
                {

                    foreach (var c in columnAttribute)
                    {
                        var columnName = c.Name;
                        mappedColumnDict.Add(pr.Name, c.Name);
                    }
                }

            }
            return mappedColumnDict;
        }

        private static TableAttribute GetTableAttributes(Type type)
        {
            //Get table Attibutes
            TableAttribute tableAttribute = null;
            IEnumerable<TableAttribute> tableAttributes = type.GetCustomAttributes<TableAttribute>(false);

            var mappedTableDict = new Dictionary<string, string>();

            if (tableAttributes.Count() > 0)
            {
                foreach (var tbl in tableAttributes)
                {
                    var tableName = tbl.Name;
                    var schemaName = tbl.Schema;
                    tableAttribute = tbl;
                }
            }
            return tableAttribute;
        }

        public static List<Dictionary<string, string>> GetDatabaseDetail(string configpath = null)
        {

            List<Dictionary<string, string>> databaseInfo = new List<Dictionary<string, string>>();

            string codeFirst = @"C:\Users\rajneesh.kumar\source\repos\EF6-Code-First-Demo-master\EF6CodeFirstDemo\App.config";

            XDocument doc = XDocument.Load(codeFirst);

            var keyvalues = doc.Root.Elements("connectionStrings")
                    .SelectMany(x => x.Elements("add")
                                            .Select(y => string.Format("ConnectionString Name={0};Database ConnectionString={1}", y.Attribute("name").Value, y.Attribute("connectionString").Value)))
                    .ToList();

            foreach (var dbstr in keyvalues)
            {
                string[] arr = dbstr.Split(';');

                string Catalog = "Initial Catalog";

                string ConnectionStringName = "ConnectionString Name";

                string dbname = null;

                string name = null;

                foreach (string a in arr)
                {

                    if (a.ToLower().Contains(Catalog.ToLower()))
                    {
                        dbname = a.Split('=')[1];
                    }
                    if (a.ToLower().Contains(ConnectionStringName.ToLower()))
                    {
                        name = a.Split('=')[1];
                    }
                }

                var dbinfo = new Dictionary<string, string>();

                dbinfo.Add(ConnectionStringName, name);

                databaseInfo.Add(dbinfo);
            };

            return databaseInfo;
        }


    }

}
