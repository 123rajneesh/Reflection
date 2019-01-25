using System.Collections.Generic;

namespace CrossCode.BLL.Domain.DBUsageStructure
{
    public class DBMappingDetails2 : DBMappingDetails, IDBUsageBoundedContext, IDBMappingDetails2
    {
        /// <summary>
        /// Gets or sets for all the ORM mapping details with database
        /// It is generic property to handle many types of situations for Table - Class 
        /// mapping details
        /// </summary>
        public List<IDBMapItem> GenericORMmapDetails
        {
            get;
            set;
        }

        public string ORMType
        {
            get;
            set;
        }

        public string ORMApproachType
        {
            get;
            set;
        }
    }
}
