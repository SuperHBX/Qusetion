using System;
using System.Collections.Generic;

namespace QADAL.EntityFrameWorkCore.Models
{
    public partial class Improvereport : Modelbase
    {
        public Nullable<int> Id { get; set; }
        public int regmanid { get; set; }
        public Nullable<System.DateTime> regdate { get; set; }
        public Nullable<int> type { get; set; }
        public string title { get; set; }
        public string reportcontent { get; set; }
        public virtual Type type1 { get; set; }
    }
}
