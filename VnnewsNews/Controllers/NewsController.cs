
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;

namespace VnnewsNews.Controllers
{
    public class NewsController : Controller
    {
        DBvnewsEntities db = new DBvnewsEntities();
        // GET: New
        public ActionResult Details(int ? id)
        {
            return View(db.News.Find(id));
        }
        public ActionResult Search(string key)
        {
            //Lam cho này
            ViewBag.key = key;
            return View();
        }
        public JsonResult CreateComment(string content, int ? id)
        {
            Comment comment = new Comment
            {
                comment_content = content,
                news_id = id,
                comment_datecreate = DateTime.Now,
                user_id = 1
            };
            db.Comments.Add(comment);
            db.SaveChanges();

            var list = from item in db.Comments
                       where item.news_id == id
                       orderby item.comment_datecreate descending
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