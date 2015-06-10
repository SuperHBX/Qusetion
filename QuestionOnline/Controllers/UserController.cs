using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QADAL.EntityFrameWorkCore.Models;
using QADAL.EntityFrameWorkCore.UnitOfWorkCore;
using QADAL.EntityFrameWorkCore;
using QADAL.EntityFrameWorkCore.Content;


namespace QuestionOnline.Controllers
{
    public class UserController :baseController
    {
        //
        // GET: /index/

        public UserController() : base(new QuestionContext()) { }


        public ActionResult Index()
        {

            
            new AnswerRepoistory(IUnitOfWork).Insert(new Answer() { anserman=2, answercontent="answer", answerdate=DateTime.Now, Id=2,Qid=2, state=true });
            
            var temp=new AnswerRepoistory(IUnitOfWork).GetModelList(o => o.Id == 2).SingleOrDefault() ;
            return View();
        }

    }
}
