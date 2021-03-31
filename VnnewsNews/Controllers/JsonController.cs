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
            var list = from item in db.News
                       where item.vnew_active == true
                       orderby item.vnew_datecreate descending
                       select new
                       {
                           id = item.user_id,
                           title = item.vnew_title,
                           category = item.Groups,
                           content = item.vnew_content,
                           view = item.vnew_view,
                           datecarete = item.vnew_datecreate,
                           vnews_des = item.vnews_des
                       };

            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public JsonResult IndexComment(int ? id)
        {
            //Làm form
            var list = from item in db.Comments
                       where item.news_id == id
                       orderby item.comment_datecreate
                       select new
                       {
                           id = item.comment_id,
                           content = item.comment_content,
                           comment_datecreate = item.comment_datecreate.ToString(),
                           name = item.User.user_name,
                           news_id = item.news_id
                       };

            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}