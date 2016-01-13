using System;
using System.Collections.Generic;

namespace QADAL.Models
{
    public partial class Log : ModelBase
    {
        public string DayLog { get; set; }
        public string RegMan { get; set; }
        public Nullable<System.DateTime> RegTime { get; set; }
        public string Adress { get; set; }
        public string Notes { get; set; }
        public int Id { get; set; }
    }
}
