using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6FluentAPIReflection
{
    public class Program
    {
        static void Main(string[] args)
        {
            FluentAPIRefelection.FluentAPIAssemblypath();

            FluentAPIRefelection.GetDatabaseDetail();

            FluentAPIRefelection.GetEntityMappingMetadta();

        }







































        #region Code for fulent API
        /*
            private static void GetDatabaseDetail(string configpath = null)
        {
            string codeFirst = @"C:\Users\rajneesh.kumar\source\repos\EF6-Code-First-Demo-master\EF6CodeFirstDemo\App.config";
            string dbFisrt = @"C:\Users\rajneesh.kumar\source\repos\EF6-DBFirst-Demo-master\EF6-DBFirst-Demo-master\EF6DBFirstDemo\App.config";

            XDocument doc = XDocument.Load(dbFisrt);

            var keyvalues = doc.Root.Elements("connectionStrings")
                    .SelectMany(x => x.Elements("add")
                                            .Select(y => string.Format("ConnectionString Name={0};Database ConnectionString={1}", y.Attribute("name").Value, y.Attribute("connectionString").Value)))
                    .ToList();

            foreach (var dbstr in keyvalues)
            {
                string[] arr = dbstr.Split(';');

                foreach (string a in arr)
                {
                    string Catalog = "Initial Catalog";
                    string ConnectionStringName = "ConnectionString Name";

                    if (a.ToLower().Contains(Catalog.ToLower()))
                    {
                        string dbname = a.Split('=')[1];
                    }
                    if (a.ToLower().Contains(ConnectionStringName.ToLower()))
                    {
                        string name = a.Split('=')[1];
                    }
                }
            };
        }

        public static void GetEntityMappingMetadta()
        {           
            SampleDBContext g = new SampleDBContext();
            
            Type type = typeof(SampleDBContext);

            var entityData = GetEntitywithProperties(type);

            var mappingData = GetFluentAPImetdata(type, g);


        }
        private static IList<ORMMetadata> GetFluentAPImetdata(Type type, SampleDBContext g)
        {

            IEnumerable<MethodInfo> mfruntime = type.GetRuntimeMethods();

            DbModelBuilder builder = new DbModelBuilder();
            foreach (var rm in mfruntime)
            {
                if (rm.Name == "OnModelCreating")
                {
                    rm.Invoke(g, new object[] { builder });
                }
            }

            var bProp = builder.GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Instance).ToList();

            object _modelConfiguration = bProp[1].GetValue(builder, null);

            var modelConfigProp = _modelConfiguration.GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Instance).Single(m => m.Name == "ActiveEntityConfigurations");

            var activeEntityConfigurations = modelConfigProp.GetValue(_modelConfiguration, null);

            //Convert Object to list
            var data = (IList)activeEntityConfigurations;


            //Getting FlunetAPI table names with entity name- First Approach Single Entity for single Table
            foreach (var d in data)
            {
                List<ORMMetadata> ormMeatadataList = null;
                var tbleNameConfigured = d.GetType().GetProperty("IsTableNameConfigured");
                var tbleNameConfiguredValue = tbleNameConfigured.GetValue(d, null);


                if ((bool)tbleNameConfiguredValue)
                {
                    //If tabel is configured in fluentAPI
                    ormMeatadataList = FluentAPISecondApproach(d, "_entityMappingConfigurations");

                    var clrType = d.GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Instance).Single(m => m.Name == "ClrType");
                    var item = clrType.GetValue(d, null);

                    //AssemblyQualifiedName = "EF6ClassLibraryFluentAPI.Employee, EF6ClassLibraryFluentAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null" = "EF6ClassLibraryFluentAPI.Employee, EF6ClassLibraryFluentAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null" = "EF6ClassLibraryFluentAPI.Employee, EF6ClassLibraryFluentAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"

                    var assembly = item.GetType().GetProperty("AssemblyQualifiedName");
                    var assemblyNameValue = assembly.GetValue(item, null);

                    var namespaceName = item.GetType().GetProperty("Namespace");
                    var namespaceNamevalue = namespaceName.GetValue(item, null);

                    var EntityName = item.GetType().GetProperty("Name");
                    var EntityNameValue = EntityName.GetValue(item, null);

                    var tableName = d.GetType().GetProperty("TableName");
                    var tableNamevalue = tableName.GetValue(d, null);


                    var schemaName = d.GetType().GetProperty("SchemaName");
                    var schemaNamevalue = schemaName.GetValue(d, null);


                    foreach (var ormMeatadata in ormMeatadataList)
                    {
                        ormMeatadata.Namespace = namespaceNamevalue?.ToString();

                        ormMeatadata.EntityName = EntityNameValue?.ToString();

                        ormMeatadata.Schema = schemaNamevalue?.ToString();

                        ormMeatadata.AssemblyName = assemblyNameValue?.ToString();

                        ExtractAssemblyname(ormMeatadata);

                        mappingList.Add(ormMeatadata);
                    }

                }
                else
                {
                    ORMMetadata ormMeatadata = new ORMMetadata();
                    //If table is not configured in FluentAPI
                    //To get the mapped column over entity property
                    var primitivePropertyConfigurations = d.GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Instance).Single(m => m.Name == "PrimitivePropertyConfigurations");
                    var PrimitivePropertyConfigurationsValue = (IDictionary)primitivePropertyConfigurations.GetValue(d);

                    foreach (var ppc in PrimitivePropertyConfigurationsValue)
                    {
                        var moc = new MemberOfClass();
                        var key = ppc.GetType().GetProperty("Key").GetValue(ppc);

                        var value = ppc.GetType().GetProperty("Value").GetValue(ppc);

                        var columnName = value.GetType().GetProperty("ColumnName").GetValue(value);
                        moc.MappedColumn = columnName.ToString();
                        var querableKeyData = ((IEnumerable)key).AsQueryable();

                        foreach (var q in querableKeyData)
                        {
                            var entityProp = q.GetType().GetProperty("Name").GetValue(q);
                            moc.PropertyName = entityProp.ToString();
                        }
                        ormMeatadata.MemberOfClass.Add(moc);
                    }
                    var clrType = d.GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Instance).Single(m => m.Name == "ClrType");
                    var item = clrType.GetValue(d, null);

                    //AssemblyQualifiedName = "EF6ClassLibraryFluentAPI.Employee, EF6ClassLibraryFluentAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null" = "EF6ClassLibraryFluentAPI.Employee, EF6ClassLibraryFluentAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null" = "EF6ClassLibraryFluentAPI.Employee, EF6ClassLibraryFluentAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"

                    var assembly = item.GetType().GetProperty("AssemblyQualifiedName");
                    var assemblyNameValue = assembly.GetValue(item, null);

                    var namespaceName = item.GetType().GetProperty("Namespace");
                    var namespaceNamevalue = namespaceName.GetValue(item, null);

                    var EntityName = item.GetType().GetProperty("Name");
                    var EntityNameValue = EntityName.GetValue(item, null);

                    var tableName = d.GetType().GetProperty("TableName");
                    var tableNamevalue = tableName.GetValue(d, null);

                    var schemaName = d.GetType().GetProperty("SchemaName");
                    var schemaNamevalue = schemaName.GetValue(d, null);


                    ormMeatadata.Namespace = namespaceNamevalue?.ToString();

                    ormMeatadata.EntityName = EntityNameValue?.ToString();

                    ormMeatadata.Schema = schemaNamevalue?.ToString();

                    ormMeatadata.AssemblyName = assemblyNameValue?.ToString();

                    ExtractAssemblyname(ormMeatadata);

                    mappingList.Add(ormMeatadata);
                }
            }

            //returning fluent API metadata

            return mappingList;
        }
        //Get Entity and properties
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

        /// <summary>
        /// Single Entity mapped with multiple tables bassed on columns
        /// </summary>
        public static List<ORMMetadata> FluentAPISecondApproach(object d, string propertyName)
        {

            var prop = d.GetType().GetField(propertyName, BindingFlags.NonPublic | BindingFlags.Instance);
            var items = (IList)prop.GetValue(d);

            List<ORMMetadata> OrmList = new List<ORMMetadata>();
            ORMMetadata ormMeatadata = null;

            //Get Mapped Tables and Properties details
            foreach (var itm in items)
            {
                ormMeatadata = new ORMMetadata();

                //Get mapped tables detail
                var tableDetail = itm.GetType().GetField("_tableName", BindingFlags.NonPublic | BindingFlags.Instance);
                var tableDetailValue = tableDetail.GetValue(itm);


                var tableName = tableDetailValue.GetType().GetProperty("Name");
                var tableNameValue = tableName.GetValue(tableDetailValue, null);
                ormMeatadata.MappedTableName = tableNameValue?.ToString();

                var schemaName = tableDetailValue.GetType().GetProperty("Schema");
                var schemaNamevalue = schemaName.GetValue(tableDetailValue, null);
                ormMeatadata.Schema = schemaNamevalue?.ToString();

                //Get mapped properties detail
                var propertiesDetail = itm.GetType().GetField("_properties", BindingFlags.NonPublic | BindingFlags.Instance);
                var propertiesDetailValue = (IList)propertiesDetail.GetValue(itm);

                List<MemberOfClass> MOClist = new List<MemberOfClass>();

                if (propertiesDetailValue != null)
                {

                    //get each column name
                    foreach (var p in propertiesDetailValue)
                    {
                        var memberOfClass = new MemberOfClass();

                        var pName = p.GetType().GetField("_components", BindingFlags.NonPublic | BindingFlags.Instance);
                        var pNamevalue = (IList)pName.GetValue(p);
                        foreach (var propVal in pNamevalue)
                        {

                            var ColumnName = propVal.GetType().GetProperty("Name");
                            var ColumnNameValue = ColumnName.GetValue(propVal, null);
                            memberOfClass.PropertyName = ColumnNameValue?.ToString();

                            MOClist.Add(memberOfClass);
                        }
                        ormMeatadata.MemberOfClass = MOClist;
                    }
                }
                OrmList.Add(ormMeatadata);
            }
            return OrmList;

        }
        private static void ExtractAssemblyname(ORMMetadata ormMeatadata)
        {
            var commaSplit = ormMeatadata.AssemblyName.Split(',');

            for (var i = 0; i < commaSplit.Length; i++)
            {

                if (commaSplit[i].Contains(ormMeatadata.EntityName))
                {
                    var dotSplit = commaSplit[i].Split('.').Where(r => r != ormMeatadata.EntityName).ToArray();

                    Console.WriteLine(commaSplit[i]);
                    Console.WriteLine(dotSplit[0]);

                    ormMeatadata.AssemblyName = string.Format("{0}.dll", dotSplit[0]);

                }


            }
        }

        private static void FluentAPIAssemblypath()
        {
            var assemblyPath = @"C:\Users\rajneesh.kumar\source\repos\EF6-Code-First-Demo-master\EF6CodeFirstDemo\bin\Debug";

            var assemblyName = string.Format(@"{0}\{1}.{2}", assemblyPath, "EF6ClassLibraryFluentAPI", "dll");

            LoadAssembly(assemblyName);
        }
        private static void CodeFirstAssemblypath()
        {
            var assemblyPath = @"C:\Users\rajneesh.kumar\source\repos\EF6-Code-First-Demo-master\EF6CodeFirstDemo\bin\Debug";

            var assemblyName = string.Format(@"{0}\{1}.{2}", assemblyPath, "EF6ClassLibrary", "dll");

            LoadAssembly(assemblyName);
        }

        /// <summary>
        /// Load Assembly from given path
        /// </summary>
        /// <param name="assemblyName"></param>
        private static void LoadAssembly(string assemblyName)
        {
            // dynamically load assembly from file Test.dll
            Assembly projectAssembly = Assembly.LoadFile(assemblyName);

            var typeInAssembly = projectAssembly.GetTypes();

           // GetTypesFromAssembly(typeInAssembly);

            Console.WriteLine(" {0} types found in Assembly {1}", typeInAssembly.Length, typeInAssembly);
        }


        ///// <summary>
        ///// Get parameter and method from members
        ///// </summary>
        ///// <param name="members"></param>
        //private static void GetMembersOfTypes(MemberInfo[] members)
        //{
        //    foreach (MemberInfo mi in members)
        //    {
        //        var meberNamespace = GetNamespace(mi);

        //        // If the member is a method, display information about its parameters.

        //        if (mi.MemberType == MemberTypes.Method)
        //        {
        //            foreach (ParameterInfo pi in ((MethodInfo)mi).GetParameters())
        //            {
        //                Console.WriteLine("Parameter: Type={0}, Name={1}", pi.ParameterType, pi.Name);
        //            }
        //        }
        //        // If the member is a property, display information about the property's accessor methods.
        //        if (mi.MemberType == MemberTypes.Property)
        //        {
        //            foreach (MethodInfo am in ((PropertyInfo)mi).GetAccessors())
        //            {
        //                Console.WriteLine("Accessor method: {0}", am);
        //            }
        //        }
        //    }
        //}

        ///// <summary>
        ///// Get members Namespace
        ///// </summary>
        ///// <param name="mi"></param>
        ///// <returns></returns>
        //private static string GetNamespace(MemberInfo mi)
        //{
        //    return mi.ReflectedType.Namespace.Trim();

        //}
         
         */
        #endregion
    }
}
