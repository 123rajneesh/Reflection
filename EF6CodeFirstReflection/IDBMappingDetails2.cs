using System.Collections.Generic;

namespace CrossCode.BLL.Domain.DBUsageStructure
{
    public interface IDBMappingDetails2
    {
        string AppnameSpaceName { get; set; }
        string DBType { get; set; }
        string NameSpaceName { get; set; }
        List<DBMapItem> ORMmapDetails { get; set; }
        string RefAssembly { get; set; }
        string DatabaseName { get; set; }
    }
}