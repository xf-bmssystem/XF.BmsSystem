using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBUtility
{
    public enum DBEnum
    {
        DPEolTestSystem,
        DPEolDataManager,
        DPEolRealDataManager,
        PackTestDB
    }

    public enum DPDBType
    {
        None,
        SqlServer,
        SQLite
    }
}
