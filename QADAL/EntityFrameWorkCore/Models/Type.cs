using System;
using System.Collections.Generic;

namespace QADAL.EntityFrameWorkCore.Models
{
    public partial class Type : Modelbase
    {
        public Type()
        {
            this.improvereports = new List<Improvereport>();
            this.questions = new List<Question>();
        }

        public int Id { get; set; }
        public string typename { get; set; }
        public virtual ICollection<Improvereport> improvereports { get; set; }
        public virtual ICollection<Question> questions { get; set; }
    }
}
