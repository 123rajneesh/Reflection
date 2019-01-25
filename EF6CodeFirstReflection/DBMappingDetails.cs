//-----------------------------------------------------------------------
// <copyright file="DBMappingDetails.cs" company="CrossCode">
//     Copyright (c) CrossCode Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CrossCode.BLL.Domain
{
    using System.Collections.Generic;

    /// <summary>
    /// Entity for Database mapping with all details
    /// </summary>
    public class DBMappingDetails : IDBUsageBoundedContext
    {
        /// <summary>
        /// Gets or sets Referred  Assembly name
        /// </summary>
        public string RefAssembly
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets for namespace name
        /// </summary>
        public string NameSpaceName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets database name
        /// </summary>
        public string DatabaseName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets for all the ORM mapping details with database
        /// </summary>
        public List<DBMapItem> ORMmapDetails
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets Actual namespace name for entity engine 
        /// </summary>
        public string AppnameSpaceName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets Database type i.e. SQL Server, Oracle, MySQL etc.
        /// </summary>
        public string DBType
        {
            get;
            set;
        }
    }
}
