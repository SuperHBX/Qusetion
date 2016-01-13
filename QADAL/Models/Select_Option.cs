using System;
using System.Collections.Generic;

namespace QADAL.Models
{
    public partial class Select_Option : ModelBase
    {
        public string SelectName { get; set; }
        public string party_id_from { get; set; }
        public string SelectItem1 { get; set; }
        public string Text { get; set; }
        public string Value { get; set; }
        public Nullable<int> sort { get; set; }
        public string note { get; set; }
        public int Id { get; set; }
    }
}
