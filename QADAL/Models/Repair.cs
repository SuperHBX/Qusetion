using System;
using System.Collections.Generic;

namespace QADAL.Models
{
    public partial class Repair : ModelBase
    {
        public string Regman { get; set; }
        public Nullable<System.DateTime> Regtime { get; set; }
        public string Manager { get; set; }
        public string RepairState { get; set; }
        public string RepairType { get; set; }
        public string RepairNote { get; set; }
        public string CheckMan { get; set; }
        public Nullable<System.DateTime> CheckTime { get; set; }
        public int Id { get; set; }
        public string CheckNote { get; set; }
        public string CheckSate { get; set; }
    }
}
