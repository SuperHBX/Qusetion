using System;
using System.Collections.Generic;

namespace QADAL.EntityFrameWorkCore.Models
{
    public partial class Question : Modelbase
    {
        public Question()
        {
            this.Answers = new List<Answer>();
            this.collects = new List<Collect>();
            
        }

        public int Id { get; set; }
        public string content { get; set; }
        public Nullable<int> typeid { get; set; }
        public string state { get; set; }
        public string regman { get; set; }
        public Nullable<System.DateTime> regdate { get; set; }
        public Nullable<bool> ishot { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<Collect> collects { get; set; }
        public virtual Type type { get; set; }
        public string title { get; set; }
    }
}
