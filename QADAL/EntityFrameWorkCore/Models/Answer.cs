using System;
using System.Collections.Generic;

namespace QADAL.EntityFrameWorkCore.Models
{
    public partial class Answer:Modelbase
    {
        public Nullable<int> Qid { get; set; }
        public string answerman { get; set; }
        public Nullable<System.DateTime> answerdate { get; set; }
        public string answercontent { get; set; }
        public int Id { get; set; }
        public Nullable<bool> state { get; set; }
        public virtual Question question { get; set; }
        public string answermanid { get; set; }
       
    }
}
