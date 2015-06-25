
using QADAL.EntityFrameWorkCore.Models;
using QAServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuestionOnline.Controllers
{
    public class QuestionController : Controller
    {

        QuestionServer qs = new QuestionServer();
        AnswerServer ans = new AnswerServer();
        CollectServer cs = new CollectServer();
        TypeServer ts = new TypeServer();
        /// <summary>
        /// 添加新问题
        /// </summary>
        /// <param name="content">问题内容</param>
        /// <param name="typeid">问题类型id</param>
        /// <param name="regman">创建人</param>
        /// <param name="ishot">是否是热门问题</param>
        public Question AddQuestion(string title,string content,int typeid,bool ishot=false) 
        {
            //验证信息

            var model = new Question()
            {
                title=title,
                content = content,
                typeid = typeid,
                regman = Common.CommonClass.GetUserName(),
                regmanid=Common.CommonClass.GetPartyIdCount(),
                regdate = DateTime.Now,
                ishot=ishot
            };
            return qs.Add(model);
        }

        /// <summary>
        /// 添加回答
        /// </summary>
        /// <param name="Qid">问题id</param>
        /// <param name="answerman">回答人</param>
        /// <param name="answercontent">回答内容</param>
        /// <returns></returns>
        public Answer AddAnswer(string Qid, string answercontent)
        {

            //验证信息

            var model = new Answer()
            {
                answerman = Common.CommonClass.GetUserName(),
                answermanid=Common.CommonClass.GetPartyIdCount(),
                answercontent = answercontent,
                answerdate = DateTime.Now,
                Qid = Convert.ToInt32(Qid)
            };
             return ans.Add(model);
        }

        /// <summary>
        /// 关键字查询
        /// </summary>
        /// <param name="Keyword">关键字</param>
        /// <returns></returns>
        public List<Question> SearchKeyword(string Keyword) 
        {
            var list =qs.FindModelList(o=>o.content.Contains(Keyword)).ToList();
            var list2 = qs.FindModelList(o => o.title.Contains(Keyword)).ToList();
            return list.Union(list2).ToList();
        }

        /// <summary>
        /// 新增热门问题
        /// </summary>
        /// <param name="qtitle">问题标题</param>
        /// <param name="qcontent">问题内容</param>
        /// <param name="typeid">问题类型</param>
        /// <param name="person">创建人</param>
        /// <param name="answercontent">回答内容</param>
        public void AddHotQuestion(string qtitle, string qcontent, int typeid,string answercontent) 
        {
            try
            {
                var model = AddQuestion(qtitle, qcontent, typeid, true);
                AddAnswer(model.Id.ToString(), answercontent);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// 删除问题
        /// </summary>
        /// <param name="Qid">问题id</param>
        public void DeleteQuestion(string Qid) 
        {
            int temp = Convert.ToInt32(Qid);
            ans.Delete(o => o.Qid == temp);
            qs.Delete(o => o.Id == temp);
        }

        /// <summary>
        ///热门问题
        /// </summary>
        /// <returns></returns>
        public List<Question> HotQuestion() 
        {
            return qs.FindModelList(o => o.ishot == true).ToList();
        }

        /// <summary>
        /// 加入收藏夹
        /// </summary>
        /// <param name="Qid">问题id</param>
        /// <param name="person">人名</param>
        /// <returns></returns>
        public string AddFavorite(string Qid)
        {
            var pid = Common.CommonClass.GetPartyIdCount();
            var temp = cs.FindModel(new object[] { Qid, pid });
            if (temp == null)
            {
                var model = new Collect()
                {
                    personid = Convert.ToInt32(pid),
                    Qid = Convert.ToInt32(Qid),
                    collecttime = DateTime.Now
                };
                cs.Add(model);
                return "收藏成功";
            }
            else
                return "不能重复收藏";
        }


        /// <summary>
        /// 获得收藏夹列表
        /// </summary>
        
        /// <returns></returns>
        public List<Collect> GetFavoriteByPerson()
        {
            var id = Common.CommonClass.GetPartyIdCount();
            return cs.FindModelList(o => o.personid == id).ToList();
        }

        /// <summary>
        /// 获取全部分类
        /// </summary>
        /// <returns></returns>
        public List<QADAL.EntityFrameWorkCore.Models.Type> GetAlltype() 
        {
            return ts.FindModelList().ToList();
        }

        public ActionResult Index()
        {
            
            var list = SearchKeyword("今");
            return View();
        }

    }
}
