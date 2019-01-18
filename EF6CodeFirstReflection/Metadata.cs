using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6CodeFirstReflection
{
    public static class Metadata
    {
        public static string GetTableName(this ObjectContext context)
        {
            var entities = context.MetadataWorkspace.GetItems(DataSpace.CSpace).Where(b => b.BuiltInTypeKind == BuiltInTypeKind.EntityType);

            foreach (var item in entities)
            {
                //if (item. == typeof(T).FullName)
                //    return item.Name;
            }

            return String.Empty;
        }
    }
}
