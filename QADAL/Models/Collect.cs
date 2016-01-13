using System;
using System.Collections.Generic;

namespace QADAL.Models
{
    public partial class Collect : ModelBase
    {
        public int Id { get; set; }
        public int personid { get; set; }
        public int Qid { get; set; }
        public Nullable<System.DateTime> collecttime { get; set; }
        public string name { get; set; }
        public virtual Question Question { get; set; }
    }
}
