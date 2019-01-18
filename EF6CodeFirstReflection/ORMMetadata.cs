using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6CodeFirstReflection
{
    public class ORMMetadata
    {
        public ORMMetadata()
        {
            MemberOfClass = new List<MemberOfClass>();
        }
        public string AssemblyName { get; set; }
        public string Namespace { get; set; }
        public string EntityName { get; set; }
        public string EntiyFullName { get; set; }
        public string MappedTableName { get; set; }
        public string Schema { get; set; }
        public List<MemberOfClass> MemberOfClass { get; set; }
    }
    public class MemberOfClass
    {
        public string PropertyName { get; set; }
        public string MappedColumn { get; set; }
    }

}
