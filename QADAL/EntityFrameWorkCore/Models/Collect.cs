using System;
using System.Collections.Generic;

namespace QADAL.EntityFrameWorkCore.Models
{
    public partial class Collect : Modelbase
    {
        public int Id { get; set; }
        public string personid { get; set; }
        public Nullable<int> Qid { get; set; }
        public Nullable<System.DateTime> collecttime { get; set; }
        public virtual Question question { get; set; }
    }
}
