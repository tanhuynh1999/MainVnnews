using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;

namespace VnnewsNews.Function
{
    public class FunctionsController : Controller
    {
        private DBvnewsEntities db = new DBvnewsEntities();
        // GET: Functions
        // GET: Hàm lấy cookie có id
        public User CookieID()
        {
            HttpCookie cookie = System.Web.HttpContext.Current.Request.Cookies["user_id"];
            if (cookie == null)
            {
                return null;
            }
            User users = db.Users.Find(Int32.Parse(cookie.Value.ToString()));
            return users;

        }
        //Hàm lấy cookie ko
        public HttpCookie Cookie()
        {
            HttpCookie cookie = System.Web.HttpContext.Current.Request.Cookies["user_id"];
            return cookie;

        }
    }
}