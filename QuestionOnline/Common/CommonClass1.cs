using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;

namespace QuestionOnline.Common
{
    public class CommonClass1
    {
        public static string GetUserPassportNumber()
        {
            string state = ConfigurationManager.AppSettings["State"];
            if (state == "Debugging")
            {
                var passport = GetCookieValue("username");
                if (string.IsNullOrEmpty(passport))
                {
                    throw new Exception("请先登录");
                }
                return GetCookieValue("username");
            }
            else
            {
                return HttpContext.Current.User.Identity.Name;
            }
        }

        /// <summary>
        /// cookie中拿当前登录人人名
        /// </summary>
        /// <returns></returns>
        public static string GetUserName()
        {
            //if (GetCookieValue("PARTYID") == null)
            //{
            //    string passportnumber = GetUserPassportNumber();
            //    SetCookie("PARTYID", PersonHelper.GetUsernameByPassportnumber(passportnumber));
            //}
            return GetCookieValue("PARTYID");
        }

        /// <summary>
        /// cookie中拿当前登录人流水号
        /// </summary>
        /// <returns></returns>
        public static int GetPartyIdCount()
        {
        //    if (GetCookieValue("PARTYIDCOUNT") == null)
        //    {
        //        string passportnumber = GetUserPassportNumber();
        //        SetCookie("PARTYIDCOUNT", PersonHelper.GetPartyidcountByPassportnumber(passportnumber).ToString());
        //    }
            return int.Parse(GetCookieValue("PARTYIDCOUNT"));
        }

        public static string GetCookieValue(string cookieName)
        {
            HttpRequest request = HttpContext.Current.Request;

            if (request != null)
            {
                HttpCookie cookie = request.Cookies[cookieName];
                if (cookie != null)
                    return HttpUtility.UrlDecode(cookie.Value, Encoding.GetEncoding("UTF-8"));
            }
            return null;
        }

        public static void SetCookie(string cookieName, string value)
        {
            HttpCookie cookie = new HttpCookie(cookieName);
            HttpResponse response = HttpContext.Current.Response;
            //cookie.Expires = expires;
            cookie.Value = HttpUtility.UrlEncode(value, Encoding.GetEncoding("UTF-8"));

            //指定客户端脚本是否可以访问[默认为false]
            cookie.HttpOnly = false;
            //指定统一的Path，比便能通存通取
            cookie.Path = "/";
            //设置跨域,这样在其它二级域名下就都可以访问到了
            //cookie.Domain = "chinesecoo.com";
            response.Cookies.Add(cookie);
        }
        

    }
}