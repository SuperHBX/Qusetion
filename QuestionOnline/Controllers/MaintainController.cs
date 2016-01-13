using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuestionOnline.Controllers
{
    public class MaintainController : Controller
    {
        // GET: Maintain
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RepairApply()
        {
            return View();
        }

        public ActionResult RepairManagement()
        {
            return View();
        }
        public ActionResult RepairLog()
        {
            return View();
        }

        public ActionResult BaseMaintenance()
        {
            return View();
        }
    }
}