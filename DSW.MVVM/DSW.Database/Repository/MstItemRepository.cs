using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using DSW.Database.Entity;
using DSW.Core.Utility.DapperLite;

namespace DSW.Database.Repository
{
    public interface IMstItemRepository : ISqlCeBaseRepository<MstItem>
    {
    }

    public class MstItemRepository : SqlCeBaseRepository<MstItem>, IMstItemRepository
    {
        public MstItemRepository(SqlCeDatabase database)
            : base(database)
        {
            //.
        }
    }
}
