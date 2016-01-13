using System;
using System.Collections.Generic;

namespace QADAL.Models
{
    public partial class Answer:ModelBase
    {
        public int Id { get; set; }
        public Nullable<int> Qid { get; set; }
        public string answerman { get; set; }
        public Nullable<System.DateTime> answerdate { get; set; }
        public string answercontent { get; set; }
        public Nullable<bool> state { get; set; }
        public string answermanid { get; set; }
        public virtual Question Question { get; set; }
    }
}
