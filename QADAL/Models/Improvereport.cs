using System;
using System.Collections.Generic;

namespace QADAL.Models
{
    public partial class ImproveReport : ModelBase
    {
        public int Id { get; set; }
        public int regmanid { get; set; }
        public Nullable<System.DateTime> regdate { get; set; }
        public Nullable<int> typeid { get; set; }
        public string title { get; set; }
        public string reportcontent { get; set; }
        public string filename { get; set; }
        public string regman { get; set; }
        public virtual Type Type { get; set; }
    }
}
