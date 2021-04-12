
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using VnnewsNews.Function;

namespace VnnewsNews.Controllers
{
    public class NewsController : Controller
    {
        FunctionsController functions = new FunctionsController();
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
                user_id = functions.CookieID().user_id
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
            var func = functions.CookieID();
            Group checkLove = db.Groups.FirstOrDefault(n => n.news_id == new_id && n.user_id == func.user_id && n.group_item == Common.Common.GROUP_THICH);
            if(checkLove == null)
            {
                Group group = new Group
                {
                    news_id = new_id,
                    user_id = functions.CookieID().user_id,
                    group_item = Common.Common.GROUP_THICH,
                    group_datecreate = DateTime.Now,
                };
                db.Groups.Add(group);
            }
            else
            {
                db.Groups.Remove(db.Groups.Find(checkLove.group_id));

            }
            db.SaveChanges();
            var list = from item in db.Groups
                       where item.news_id == new_id && item.user_id == functions.CookieID().user_id && item.group_item == Common.Common.GROUP_THICH
                       select new
                       {
                           id = item.group_id
                       };
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        //Danh sách Tin tức yêu thích
        public ActionResult IndexFavourite()
        {
            if (functions.CookieID() == null)
            {
                return Redirect("/Account/Login");
            }
            return View();
        }

        public ActionResult MyNews()
        {
            if (functions.CookieID() == null)
            {
                return Redirect("/Account/Login");
            }
            return View();
        }
        public JsonResult Remove(int? id)
        {
            if(id == null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            var user = functions.CookieID();
            var removeItem = db.Groups.FirstOrDefault(t => t.news_id == id && t.user_id == user.user_id);
            db.Groups.Remove(removeItem);
            db.SaveChanges();
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        //Danh sách Hoat dộng tin tức (comment, like)
        //Chia 2 cái row : 1 bên là thông báo comment và còn lại là đã like
        //Có khả năng làm real time
        public ActionResult IndexActive()
        {
            return View();
        }
        public ActionResult AllNews()
        {
            return View();
        }
        // Chi tiết tin tức
    }
}