
using QADAL.Models;
using QAServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using QuestionOnline.Models;
using SgidiHelpers;
using SK_TodoList;
using System.Xml.Linq;
using System.Net;
using System.Collections.Specialized;
using System.Text;
using System.Security.Cryptography;

namespace QuestionOnline.Controllers
{
    public class QuestionController : baseController
    {
         
        QuestionServer qs = new QuestionServer();
        AnswerServer ans = new AnswerServer();
        CollectServer cs = new CollectServer();
        TypeServer ts = new TypeServer();
        SelectOptionServer so = new SelectOptionServer();
        ITodoService service = SK_TodoList.TodoEngine.GetTodoService();
        /// <summary>
        /// 提问页
        /// </summary>
        /// <returns></returns>
        public ActionResult AskQuestion() 
        {
            ViewBag.User = Common.CommonClass1.GetUserName();
            ViewBag.HotQuestion = HotQuestion().OrderByDescending(o => o.regdate).Take(10);
            ViewBag.Types = GetAlltype();
            return View();
        }

        /// <summary>
        /// 详情页
        /// </summary>
        /// <returns></returns>
        public ActionResult QuestionDetail(int Qid=1,string pid=null) 
        {
            try
            {
                if (pid != null)
                    service.DeleteTodo(pid);
            }
            catch (Exception)
            {

                throw;
            }
            
            var temp = qs.FindModel(new object[] { Qid });
            ViewBag.TypeList = ts.FindModelList();
            ViewBag.Types = GetAlltype();
            ViewBag.HotQuestion = HotQuestion().OrderByDescending(o => o.regdate).Take(10);
            var list = so.FindModelList().Where(o=>o.SelectItem1=="管理员"&&o.party_id_from==temp.Type.typename&&o.Text==Common.CommonClass1.GetUserName()).ToList();
           
            

           ViewBag.IsManager = (list.Count()>0&&temp.state=="1");
           return View(temp);
        }

        /// <summary>
        /// 热门问题编辑
        /// </summary>
        /// <returns></returns>
        public ActionResult EditorHot()
        {
            ViewBag.HotQuestion = HotQuestion().OrderByDescending(o => o.regdate).Take(10);
            ViewBag.Types = GetAlltype();
            return View();
        }

        /// <summary>
        /// 右边栏
        /// </summary>
        /// <returns></returns>
        public ActionResult RightContent()
        {
            
            return View();
        }

        /// <summary>
        /// 添加新问题
        /// </summary>
        /// <returns></returns>
        [ValidateInput(false)]
        public ActionResult AddQuestionV2(Question model) 
        {
            model.regman = Common.CommonClass1.GetUserName();
            model.regmanid = Common.CommonClass1.GetPartyIdCount();
            
            var temp=qs.Add(model);
            return Json(temp, JsonRequestBehavior.AllowGet);
        }
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
                regman = Common.CommonClass1.GetUserName(),
                regmanid=Common.CommonClass1.GetPartyIdCount(),
                regdate = DateTime.Now,
                ishot=ishot
            };
            return qs.Add(model);
        }

        /// <summary>
        /// 添加回答
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ValidateInput(false)]
        public ActionResult AddAnswer(Answer model) 
        {
            model.answerdate = DateTime.Now;
            model.answerman = Common.CommonClass1.GetUserName();
            model.answermanid = Common.CommonClass1.GetPartyIdCount().ToString();
            model.state = true;
            var temp = ans.Add(model);
            var questionmodel = qs.FindModelList(o => o.Id == model.Qid).FirstOrDefault();
            questionmodel.state = "0";
            qs.UpDate(questionmodel);
            return Json(temp, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 添加回答
        /// </summary>
        /// <param name="Qid">问题id</param>
        /// <param name="answerman">回答人</param>
        /// <param name="answercontent">回答内容</param>
        /// <returns></returns>
        //public Answer AddAnswer(string Qid, string answercontent)
        //{

        //    //验证信息

        //    var model = new Answer()
        //    {
        //        answerman = Common.CommonClass.GetUserName(),
        //        answermanid=Common.CommonClass.GetPartyIdCount().ToString(),
        //        answercontent = answercontent,
        //        answerdate = DateTime.Now,
        //        Qid = Convert.ToInt32(Qid)
        //    };
        //     return ans.Add(model);
        //}

        /// <summary>
        /// 关键字查询
        /// </summary>
        /// <param name="Keyword">关键字</param>
        /// <returns></returns>
        //public ActionResult SearchKeyword(string Keyword) 
        //{
        //    var list =qs.FindModelList(o=>o.content.Contains(Keyword)).ToList();
        //    var list2 = qs.FindModelList(o => o.title.Contains(Keyword)).ToList();
        //    var AList=list.Union(list2).ToList();
        //    //QuestionOnline.Common.PageSplit.GetPageCount(AList, 5);
        //    return View("SearchResults", AList);
        //}
        
        public ActionResult SearchKeyword(string Keyword,int page=1)
        {
            int pagenumber = 6;
            var list = qs.FindModelList(o => o.content.Contains(Keyword)).ToList();
            var list2 = qs.FindModelList(o => o.title.Contains(Keyword)).ToList();
            var AList = list.Union(list2).ToList();

            IList<QADAL.Models.Question> SList = new List<QADAL.Models.Question>();
            ViewBag.keyword = Keyword;
            ViewBag.count = AList.Count();
            ViewBag.TypeList = ts.FindModelList();
            ViewBag.page = page;
            ViewBag.allpage = Math.Ceiling((double)AList.Count() / (double)pagenumber);
            SList = AList.Skip((page - 1) * pagenumber).Take(pagenumber).OrderByDescending(o => o.regdate).ToList();
            ViewBag.user = Common.CommonClass1.GetUserName();
            return View("SearchResults", SList);
        }

        /// <summary>
        /// 新增热门问题
        /// </summary>
        /// <param name="qtitle">问题标题</param>
        /// <param name="qcontent">问题内容</param>
        /// <param name="typeid">问题类型</param>
        /// <param name="person">创建人</param>
        /// <param name="answercontent">回答内容</param>
        //public void AddHotQuestion(string qtitle, string qcontent, int typeid,string answercontent) 
        //{
        //    try
        //    {
        //        var model = AddQuestion(qtitle, qcontent, typeid, true);
        //        AddAnswer(model.Id.ToString(), answercontent);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }

        //}

        /// <summary>
        /// 删除问题
        /// </summary>
        /// <param name="Qid">问题id</param>
        public void DeleteQuestion(int Qid) 
        {
            try
            {
                //int temp = Convert.ToInt32(Qid);
                ans.Delete(o => o.Qid == Qid);
                qs.Delete(o => o.Id == Qid);
                Response.Write("ok");
            }
            catch (Exception ex)
            {

                Response.Write(ex.Message);
            }
           
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
        public string AddFavorite(int Qid)
        {
            var pid = Common.CommonClass1.GetPartyIdCount();
            var name=Common.CommonClass1.GetUserName();
            //var temp = cs.FindModel(new object[] { Qid, pid });
            var temp = cs.FindModelList(o => o.personid == pid && o.Qid == Qid).FirstOrDefault();
            if (temp == null)
            {
                var model = new Collect()
                {
                    personid = Convert.ToInt32(pid),
                    Qid = Convert.ToInt32(Qid),
                    collecttime = DateTime.Now,
                    name = name
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
            var id = Common.CommonClass1.GetPartyIdCount();
            return cs.FindModelList(o => o.personid == id).ToList();
        }

        /// <summary>
        /// 获取全部分类
        /// </summary>
        /// <returns></returns>
        public List<QADAL.Models.Type> GetAlltype() 
        {
            return ts.FindModelList().ToList();
        }

        public ActionResult Index()
        {
            
           // var list = SearchKeyword("今");
            return View();
        }
        public ActionResult Question(int? module=null,string parenttype=null,string childtype=null,int page=1)
        {
            ViewBag.HotQuestion = HotQuestion().OrderByDescending(o => o.regdate).Take(10);
            int pagenumber = 6;
            IEnumerable<Question> list = qs.FindModelList().ToList().OrderByDescending(o => o.regdate);

            //if (module != null) 
            //{
            //    list = list.Where(o => o.typeid == module);
            //}

            if (parenttype != null) 
            {
                int manid = 1;//Common.CommonClass.GetPartyIdCount();
                switch(parenttype)
                { 
                    case "allquestion"://所有收藏
                        list = qs.FindModelList().OrderByDescending(o => o.regdate);
                        break;
                    case "myquestion":                        
                        list = list.Where(o => o.regmanid == manid).OrderByDescending(o => o.regdate);
                        break;
                    case "collect":
                        list = cs.FindModelList(o => o.personid == manid).GroupBy(o => o.Question).Select(o => o.Key).OrderByDescending(o => o.regdate);
                        break;                                     
                }
                    
            }
            if (childtype != null && parenttype != "collect") 
            {
                //int manid = Common.CommonClass.GetPartyIdCount();
                switch (parenttype)
                {
                    case "all":
                        break;
                    case "resolved"://已解决
                        list = list.Where(o => o.state == "0").OrderByDescending(o => o.regdate);
                        break;
                    case "unsolved"://未解决
                        list = list.Where(o => o.state == "1").OrderByDescending(o => o.regdate);
                        break;                 
                      
                }
            }
           ViewBag.username = Common.CommonClass1.GetUserName();
           ViewBag.count = list.Count();                 
           ViewBag.TypeList = ts.FindModelList();
           ViewBag.page = page;
           ViewBag.allpage =Math.Ceiling((double)list.Count() / (double)pagenumber);
           list = list.Skip((page - 1) * pagenumber).Take(pagenumber).OrderByDescending(o=>o.regdate);
           return View(list);
        }
        public ActionResult GetQuestionByPage(int? module = null, string parenttype = null, string childtype = null, int page = 1) 
        {
            int pagenumber = 6;//每页6条
            IEnumerable<Question> list = qs.FindModelList().ToList().OrderByDescending(o => o.regdate);

            //if (module != null) 
            //{
            //    list = list.Where(o => o.typeid == module);
            //}

            if (parenttype != null)
            {
               // int manid = 1;
                int manid = Common.CommonClass1.GetPartyIdCount();
                switch (parenttype)
                {
                    case "allquestion"://所有收藏
                        list = qs.FindModelList().OrderByDescending(o => o.regdate);
                        break;
                    case "myquestion":
                        list = list.Where(o => o.regmanid == manid).OrderByDescending(o => o.regdate);
                        break;
                    case "collect":
                        list = cs.FindModelList(o => o.personid == manid).GroupBy(o => o.Question).Select(o => o.Key).OrderByDescending(o => o.regdate);
                        break;
                }

            }
            if (childtype != null && parenttype != "collect")
            {
                switch (childtype)
                {
                    case "all":
                        break;
                    case "resolved"://已解决
                        list = list.Where(o => o.state == "0").OrderByDescending(o => o.regdate);
                        break;
                    case "unsolved"://未解决
                        list = list.Where(o => o.state == "1").OrderByDescending(o => o.regdate);
                        break;

                }    
            }


            if (module != -1)
            {
                list = list.Where(o => o.typeid == module).OrderByDescending(o => o.regdate);
            }

            var model = new QuestionCountModel();
            model.allcount = list.Count();//总个数

            list = list.Skip((page - 1) * pagenumber).Take(pagenumber).ToList();
            var templist = new List<QuestionPageModel>();
            foreach (var i in list)
            {
                i.Type.Questions.Clear();
                i.Type.Improvereports.Clear();
                var answer = new Answer();
                if (i.Answers.Count!=0)
                {
                    answer = i.Answers.ToList().FirstOrDefault();
                    answer.Question = null;
                }
                templist.Add(new QuestionPageModel() 
                {
                    ishot=i.ishot,
                    Id=i.Id,
                    state=i.state,
                    regdate=i.regdate,
                    regman=i.regman,
                    regmanid=i.regmanid,
                    title=i.title,
                    Type=i.Type,
                    Answer = answer,
                    content=i.content,
                    typeid=i.typeid                         
                });
           
            }
            templist = templist.OrderByDescending(o => o.regdate).ToList();
            model.list = templist;
            return Json(model, JsonRequestBehavior.AllowGet);
        }


        //public int GetQuestionCount(int? module = null, string parenttype = null, string childtype = null) 
        //{
        //    IEnumerable<Question> list = qs.FindModelList().ToList().OrderByDescending(o => o.regdate);

        //    //if (module != null) 
        //    //{
        //    //    list = list.Where(o => o.typeid == module);
        //    //}

        //    if (parenttype != null)
        //    {
        //        int manid = 1;//Common.CommonClass.GetPartyIdCount();
        //        switch (parenttype)
        //        {
        //            case "allquestion"://所有收藏
        //                list = qs.FindModelList().OrderByDescending(o => o.regdate);
        //                break;
        //            case "myquestion":
        //                list = list.Where(o => o.regmanid == manid).OrderByDescending(o => o.regdate);
        //                break;
        //            case "collect":
        //                list = cs.FindModelList(o => o.personid == manid).GroupBy(o => o.question).Select(o => o.Key).OrderByDescending(o => o.regdate);
        //                break;
        //        }

        //    }
        //    if (childtype != null && parenttype != "collect")
        //    {
        //        //int manid = Common.CommonClass.GetPartyIdCount();
        //        switch (parenttype)
        //        {
        //            case "all":
        //                break;
        //            case "resolved"://已解决
        //                list = list.Where(o => o.state == "0").OrderByDescending(o => o.regdate);
        //                break;
        //            case "unsolved"://未解决
        //                list = list.Where(o => o.state == "1").OrderByDescending(o => o.regdate);
        //                break;

        //        }
        //    }

        //    return list.Count();
        //}

        public void SendMsg(int type)
        {
            
            var typename = ts.FindModelList(o => o.Id == type).FirstOrDefault().typename;
            var phone = so.FindModelList().Where(o => o.party_id_from == typename).FirstOrDefault().note;
            try
            {
                //SgidiHelpers.MsgSendingHelper.Send(assgine, );
                XElement root = new XElement("message",
                new XElement("account", "dh1993"), //账号 dh1993 
                new XElement("password", md5("yt123.com")), //密码 yt123.com 
                new XElement("msgid", ""),
                new XElement("phones", string.Join(",", new List<string>() { phone }.ToArray())), //电话号码，多个号码用小写逗号分隔 
                new XElement("content", "您有一个答疑平台的待解决问题请及时处理"), //短信内容 
                new XElement("sign", "【上海岩土院】"), //短信签名内容 
                new XElement("subcode", ""),
                new XElement("sendtime", ""));

                string xmlString = "<?xml version='1.0' encoding='UTF-8'?>" + root.ToString(SaveOptions.DisableFormatting);

                WebClient webClient = new WebClient();
                NameValueCollection postValues = new NameValueCollection();
                postValues.Add("message", xmlString);

                //向服务器发送POST数据 
                string url = "http://3tong.net/http/sms/Submit";
                byte[] responseArray = webClient.UploadValues(url, postValues);
                string send_result = Encoding.UTF8.GetString(responseArray);
                //return send_result;
                //return "";
                Response.Write("ok");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            
        }

        private static string md5(string str)
        {
            byte[] result = Encoding.Default.GetBytes(str);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            String md = BitConverter.ToString(output).Replace("-", "");
            return md.ToLower();
        }

        public void SendTodo(string owner,int type,string qid)
        {
            var typename = ts.FindModelList(o => o.Id == type).FirstOrDefault().typename;
            var assgine = so.FindModelList().Where(o => o.party_id_from == typename).FirstOrDefault().Value;

            try
            {   
                var service=SK_TodoList.TodoEngine.GetTodoService();
#if DEBUG
                service.SendTodo(assgine + "-" + qid, typename, int.Parse(assgine), "您有一个答疑平台的待解决问题", owner + "的" + typename + "的问题", "", "http://192.168.11.8:30002/Question/QuestionDetail?Qid=" + qid + "&pid=" + assgine + "-" + qid);
#else
                
                service.SendTodo(assgine + "-" + qid, typename, int.Parse(assgine), "您有一个答疑平台的待解决问题", owner + "的" + typename + "的问题", "", "http://192.168.2.8:10050/Question/QuestionDetail?Qid=" + qid + "&pid=" + assgine + "-" + qid);
#endif
                Response.Write("ok");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }

        }

        public ActionResult EditorQuestion(int id)
        {
            var Question = qs.FindModel(new object[] { id });
            ViewBag.Types = GetAlltype();
            return View(Question);
        }

        public ActionResult SelectOption()
        {
            return View();
        }




        public void UpdateQuestion(int Qid)
        {
            try
            {
                var question = qs.FindModel(new object[] { Qid });
                question.typeid = int.Parse(Request.Form["typeid"]);
                question.title = Request.Form["title"];
                question.content = Request.Form["content"];
                var answer = new Answer();
                if (Request.Form.AllKeys.Contains("answercontent"))
                {
                    answer = ans.FindModelList().Where(o => o.Qid == Qid).FirstOrDefault();
                    answer.answercontent = Request.Form["answercontent"];
                }
                ans.UpDate(answer);
                qs.UpDate(question);
            }
            catch (Exception ex)
            {

                Response.Write(ex.Message);
            }
           
               
        }
        private List<Question> GetAllQuestion()
        {      
            return qs.FindModelList().ToList();
        }


        


    }
}
