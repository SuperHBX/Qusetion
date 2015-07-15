using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QADAL.EntityFrameWorkCore.UnitOfWorkCore;
using QADAL.EntityFrameWorkCore;


namespace QuestionOnline.Controllers
{
    public class baseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.ActionDescriptor.ActionName != "Index" && filterContext.ActionDescriptor.ControllerDescriptor.ControllerName != "User")
            {
                if (Common.CommonClass1.GetCookieValue("username") == null)
                {
                    filterContext.Result = RedirectToAction("Index", "User");
                }
                base.OnActionExecuting(filterContext);
            }
        }


       
    }
}
