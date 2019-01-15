using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DSW.Database.Entity
{
    public class AppSetting
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
