using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QADAL.EntityFrameWorkCore.Models;
using QADAL.EntityFrameWorkCore.UnitOfWorkCore;
using QADAL.EntityFrameWorkCore;
using QADAL.EntityFrameWorkCore.Content;
using QAServer.Server;


namespace QuestionOnline.Controllers
{

    public class UserController : baseController
    {
          
        private QuestionServer qs=new QuestionServer();

        public ActionResult Index()
        {

            
            //new AnswerRepoistory(IUnitOfWork).Insert(new Answer() { anserman=2, answercontent="answer", answerdate=DateTime.Now,Qid=2, state=true });


            //new AnswerRepoistory(IUnitOfWork).Update(o => new Answer { });
            //var temp = new AnswerRepoistory(IUnitOfWork).GetModelList().SingleOrDefault();

            
           //var temp= qs.Add(new Question() {content="123", ishot=true, regdate=DateTime.Now, regman=1, state="1", typeid=1 });

           var list = qs.FindModelList().ToList();
           return View();
        }

    }
}
