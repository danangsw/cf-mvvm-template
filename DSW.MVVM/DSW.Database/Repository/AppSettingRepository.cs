using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using DSW.Database.Entity;
using DSW.Core.Utility.DapperLite;

namespace DSW.Database.Repository
{
    public interface IAppSettingRepository : ISqlCeBaseRepository<AppSetting>
    {
    }

    public class AppSettingRepository : SqlCeBaseRepository<AppSetting>, IAppSettingRepository
    {
        public AppSettingRepository(SqlCeDatabase database)
            : base(database)
        {
            //.
        }
    }
}
