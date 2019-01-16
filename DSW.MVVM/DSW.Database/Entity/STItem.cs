using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DSW.Database.Entity
{
    public class STItem
    {
        public int Id { get; set; }
        public string ItemNo { get; set; }
        public string ItemDesc { get; set; }
        public decimal Qty { get; set; }
        public decimal ActQty { get; set; }
        public string ScannedUser { get; set; }
        public DateTime? ScannedDate { get; set; }
    }
}
