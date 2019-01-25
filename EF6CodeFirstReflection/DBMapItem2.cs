using System;
using System.Collections.Generic;

namespace CrossCode.BLL.Domain.DBUsageStructure
{
   public class DBMapItem2 : DBMapItem, IDBMapItem, ICloneable
    {
        /// <summary>
        /// Gets or sets mapped class in an ORM for a table
        /// </summary>
        public string MappedSchemaName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets mapped class in an ORM for a table
        /// </summary>
        public string MappedNamespace
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets mapped class in an ORM for a table
        /// </summary>
        public string MappedAssembly
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets Mapped column property in an ORM
        /// 1 Method - N Columns
        /// </summary>
        public Dictionary<string, string> CollectionOFMappedColumnProperties
        {
            get;
            set;
        }

        public bool IsClassMappedToMultipleColumn
        {
            get;
            set;
        }
        public object Clone()
        {
           return (DBMapItem2)this.MemberwiseClone();
        }
    }
}
