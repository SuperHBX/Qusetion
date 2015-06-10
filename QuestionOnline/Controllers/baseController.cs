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
        //
        // GET: /base/


        protected IUnitOfWork IUnitOfWork { get; private set; }

        public baseController(IUnitOfWork _iUnitOfWork)
        {
            IUnitOfWork = _iUnitOfWork;
        }
    }
}
