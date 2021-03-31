
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

        public JsonResult Favourite(int? new_id)
        {
            Group checkLove = db.Groups.SingleOrDefault(n => n.news_id == new_id && n.user_id == 1 && n.group_item == Common.Common.GROUP_THICH);
            if(checkLove == null)
            {
                Group group = new Group
                {
                    news_id = new_id,
                    user_id = 1,
                    group_item = Common.Common.GROUP_THICH,
                    group_datecreate = DateTime.Now,
                };
                db.Groups.Add(group);
                db.SaveChanges();
            }
            else
            {
                db.Groups.Remove(db.Groups.Find(checkLove.group_id));
                db.SaveChanges();

            }
            var list = from item in db.Groups
                       where item.news_id == new_id && item.user_id == 1 && item.group_item == Common.Common.GROUP_THICH
                       select new
                       {
                           id = item.group_id
                       };
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        //Danh sách Tin tức yêu thích
        public ActionResult IndexFavourite()
        {
            return View();
        }
        //Danh sách Hoat dộng tin tức (comment, like)
        //Chia 2 cái row : 1 bên là thông báo comment và còn lại là đã like
        //Có khả năng làm real time
        public ActionResult IndexActive()
        {
            return View();
        }
    }
}