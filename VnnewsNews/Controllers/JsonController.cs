using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;

namespace VnnewsNews.Controllers
{
    public class JsonController : Controller
    {
        DBvnewsEntities db = new DBvnewsEntities();
        // GET: Json
        //Danh sách tất cả tin tức bang json
        public JsonResult IndexNews(string key)
        {
            //Làm form
            //List<News> news = db.News.Where(n => n.vnew_active == true && n.vnew_option == true).ToList();
            return Json(11);
        }
    }
}