using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;

namespace QuestionOnline.Common
{
    public class CommonClass
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


        

    }
}