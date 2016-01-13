
using QADAL.Models;
using QAServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuestionOnline.Controllers
{
    public class BackUpController : baseController
    {
        ImproveReportServer ir = new ImproveReportServer();
        TypeServer ts = new TypeServer();
        //public ImproveReport AddReport(string typeid,string title,string content,string filename) 
        //{
        //    //验证数据

        //    var model = new ImproveReport() 
        //    {
        //        regdate=DateTime.Now,
        //        regman=Common.CommonClass1.GetUserName(),
        //        regmanid=Common.CommonClass1.GetPartyIdCount(),
        //        reportcontent=content,
        //        title=title,
        //        typeid=Convert.ToInt32(typeid)
        //    };
        //    return ir.Add(model);
        //}



        public ActionResult Index()
        {
            return View();
        }
        public ActionResult report(int month)
        {
            var list = ir.FindModelList(o => o.regdate.Value.Month == month).ToList();
            ViewBag.ReportList = list;
            ViewBag.Types = ts.FindModelList();
            return View(list);
        }
        /// <summary>
        ///添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ValidateInput(false)]
        public ActionResult AddReport(ImproveReport model)
        {
            model.regman = Common.CommonClass1.GetUserName();
            model.regmanid = Common.CommonClass1.GetPartyIdCount();
            model.regdate = DateTime.Now;
            return Json(ir.Add(model),JsonRequestBehavior.AllowGet);
           
        }
    }
}
