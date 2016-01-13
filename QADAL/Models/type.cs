using System;
using System.Collections.Generic;

namespace QADAL.Models
{
    public partial class Type : ModelBase
    {
        public Type()
        {
            this.Improvereports = new List<ImproveReport>();
            this.Questions = new List<Question>();
        }

        public int Id { get; set; }
        public string typename { get; set; }
        public string img { get; set; }
        public virtual ICollection<ImproveReport> Improvereports { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}
