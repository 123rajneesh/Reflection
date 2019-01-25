//-----------------------------------------------------------------------
// <copyright file="DBMapItem.cs" company="CrossCode">
//     Copyright (c) CrossCode Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using CrossCode.BLL.Domain.DBUsageStructure;

namespace CrossCode.BLL.Domain
{
    using System.Collections.Generic;

    /// <summary>
    /// Entity class for database mapping
    /// </summary>
    public class DBMapItem
    {
        public DBMapItem()
        {
        }

        /// <summary>
        /// Gets or sets for Table Name identifier
        /// </summary>
        public string TblNameKey
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets mapped class in an ORM for a table
        /// </summary>
        public string MappedClass
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets Mapped column property in an ORM
        /// </summary>
        public List<string> MappedColumnProperty
        {
            get;
            set;
        }
    }
}
