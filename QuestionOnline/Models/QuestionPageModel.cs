using QADAL.EntityFrameWorkCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuestionOnline.Models
{
    public class QuestionPageModel
    {
        public int Id { get; set; }
        public string content { get; set; }
        public Nullable<int> typeid { get; set; }
        public string state { get; set; }
        public string regman { get; set; }
        public Nullable<int> regmanid { get; set; }
        public Nullable<System.DateTime> regdate { get; set; }
        public Nullable<bool> ishot { get; set; }
        public Answer Answer { get; set; }
        public virtual QADAL.EntityFrameWorkCore.Models.Type Type { get; set; }
        public string title { get; set; }
    }
}