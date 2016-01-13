using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QADAL.Models;
using QADAL.EntityFrameWorkCore.UnitOfWorkCore;
using QADAL.EntityFrameWorkCore;
using QADAL.EntityFrameWorkCore.Content;
using QAServer.Server;
using System.Data;
using System.Data.SqlClient;

using QuestionOnline.Common;



namespace QuestionOnline.Controllers
{

    public class UserController : baseController
    {
          
        private QuestionServer qs=new QuestionServer();

        public ActionResult Index()
        {
           return View();
        }

        public string login(string username) 
        {

            HttpCookie aCookie;
            string cookieName;
            int limit = Request.Cookies.Count;
            for (int i = 0; i < limit; i++)
            {
                cookieName = Request.Cookies[i].Name;
                aCookie = new HttpCookie(cookieName);
                aCookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(aCookie);
            }

            string str = "Data Source=192.168.11.8;Initial Catalog=mybo;User Id=softuser;Password=geo2003;";
            using(SqlConnection sqlCon = new SqlConnection(str))
            {
               
                string strsql = "select * FROM [PERSON] where PARTY_ID='" + username+"'";
                SqlDataAdapter sqlda = new SqlDataAdapter(strsql, sqlCon);
                DataSet ds = new DataSet();
                sqlda.Fill(ds);

                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    CommonClass1.SetCookie("username", dt.Rows[0]["PASSPORT_NUMBER"].ToString());
                    CommonClass1.SetCookie("PARTYID", dt.Rows[0]["PARTY_ID"].ToString());
                    CommonClass1.SetCookie("PARTYIDCOUNT", dt.Rows[0]["PARTY_ID_COUNT"].ToString());
                   
                    
                    return "成功";
                }
                else
                {
                   
                    return "不存在";
                }
            }

        }

    }
}
