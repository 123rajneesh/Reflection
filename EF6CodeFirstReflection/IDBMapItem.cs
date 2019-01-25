//-----------------------------------------------------------------------
// <copyright file="DBMapItem.cs" company="CrossCode">
//     Copyright (c) CrossCode Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.Generic;

namespace CrossCode.BLL.Domain.DBUsageStructure
{
    public interface IDBMapItem : IDBUsageBoundedContext
    {
        /// <summary>
        /// Gets or sets for Table Name identifier
        /// </summary>
        string TblNameKey
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets mapped class in an ORM for a table
        /// </summary>
        string MappedSchemaName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets mapped class in an ORM for a table
        /// </summary>
        string MappedAssembly
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets mapped class in an ORM for a table
        /// </summary>
        string MappedClass
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets Mapped column property in an ORM
        /// </summary>
        Dictionary<string,string > CollectionOFMappedColumnProperties
        {
            get;
            set;
        }
        //Dictionary<ComplexType, string> CollectionOFMappedColumnProperties2
        //{
        //    get;
        //    set;
        //}
    }

   public class ComplexType
    {
        public bool IsComplexType { get; set; }
        public string PropertyName { get; set; }
        public string AssemblyName { get; set; }
        public string Nms { get; set; }
        public string ClassName { get; set; }
    }
}