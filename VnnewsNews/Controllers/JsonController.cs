using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using VnnewsNews.Function;

namespace VnnewsNews.Controllers
{
    public class JsonController : Controller
    {
        DBvnewsEntities db = new DBvnewsEntities();
        FunctionsController functions = new FunctionsController();
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
                           vnews_des = item.vnews_des,
                           img = item.vnew_img,
                           user_name = item.User.user_name
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
        public JsonResult favourite(int? id)
        {
            //Làm form
            var user = functions.CookieID();
            var list = from item in db.Groups
                       where item.news_id == id && item.user_id == user.user_id && item.group_item == Common.Common.GROUP_THICH
                       select new
                       {
                           id = item.group_id
                       };
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public JsonResult MyNews()
        {

            //Làm form
            var user = functions.CookieID();
            var list = from item in db.News
                       where item.user_id == user.user_id
                       select new
                       {
                           id = item.user_id,
                           title = item.vnew_title,
                           img = item.vnew_img,
                           content = item.vnew_content,
                           view = item.vnew_view,
                           category = item.Groups.Select(t => t.Category.category_name),
                           author = item.User.user_name,
                           dateadd = item.vnew_datecreate.ToString(),
                       };
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult FavoriteNews()
        {

            //Làm form
            var user = functions.CookieID();
            var list = from item in db.Groups
                       where item.user_id == user.user_id
                       select new
                       {
                           id = item.News.user_id,
                           title = item.News.vnew_title,
                           author = item.News.User.user_name,
                           dateadd = item.group_datecreate.ToString(),
                       };
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        // yeu thich ca nhan
        public JsonResult MyFavorite()
        {

            //Làm form
            var user = functions.CookieID();
            var list = from item in db.Groups
                       where item.user_id == user.user_id
                       select new
                       {
                           id = item.News.user_id,
                           title = item.News.vnew_title,
                           author = item.News.User.user_name,
                           dateadd = item.group_datecreate.ToString(),
                           news_id = item.news_id
                       };
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        // xoa yeu thich
        public JsonResult RemoveMyFavorite(int? id)
        {
            var removeItem = db.Groups.Find(id);
            db.Groups.Remove(removeItem);
            db.SaveChanges();
            //Làm form
            var user = functions.CookieID();
            var list = from item in db.Groups
                       where item.user_id == user.user_id
                       select new
                       {
                           id = item.News.user_id,
                           title = item.News.vnew_title,
                           author = item.News.User.user_name,
                           dateadd = item.group_datecreate.ToString(),
                           news_id = item.news_id
                       };
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Active()
        {

            //Làm form
            var user = functions.CookieID();
            var list = from item in db.News
                       where item.user_id == user.user_id
                       select new
                       {
                           vnew_title = item.vnew_title,
                           vnew_datecreate = item.vnew_datecreate
                       };
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        // quang cao ca nhan
        public JsonResult MyAds()
        {
            var user = functions.CookieID();
            var list = from item in db.Ads
                       where item.user_id == user.user_id
                       select new
                       {
                           id = item.ads_id,
                           title = item.ads_title,
                           poster = item.ads_poster,
                           money = item.ads_money,
                           option = item.ads_option,
                           totalday = item.ads_totalday,
                           datecreate = item.ads_datecreate.ToString(),
                           dateend = item.ads_dateend
                       };
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        // Chi tiết tin tức
        public JsonResult AllNews()
        {
            var user = functions.CookieID();
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
                           datecarete = item.vnew_datecreate.ToString(),
                           vnews_des = item.vnews_des,
                           img = item.vnew_img,
                           user_name = item.User.user_name
                       };

            return Json(list, JsonRequestBehavior.AllowGet);
        }
        // lich su thanh toan
        public JsonResult HistoryPays()
        {
            var user = functions.CookieID();
            //Làm form
            var list = from item in db.Bills
                       where item.user_id == user.user_id
                       select new
                       {
                           id = item.user_id,
                           title = item.Ad.ads_title,
                           money = item.bill_summoney,
                           datecarete = item.bill_datecreate.ToString(),
                           user_name = item.User.user_name
                       };

            return Json(list, JsonRequestBehavior.AllowGet);
        }


        // danh sach rut tien
        public JsonResult GetHistoryTakePrice()
        {
            var user = functions.CookieID();
            //Làm form
            var list = from item in db.TakePrices
                       where item.user_id == user.user_id
                       select new
                       {
                           id = item.tp_id,
                           user_id = item.user_id,
                           money = item.tp_totalmoney,
                           datecarete = item.tp_datecreate,
                           phone = item.User.user_phone
                       };

            return Json(list, JsonRequestBehavior.AllowGet);
        }

        // danh sach rut tien
        public JsonResult RemoveHistoryTakePrice(int? id)
        {
            var removeItem = db.TakePrices.Find(id);
            db.TakePrices.Remove(removeItem);
            db.SaveChanges();
            var user = functions.CookieID();
            //Làm form
            var list = from item in db.TakePrices
                       where item.user_id == user.user_id
                       select new
                       {
                           id = item.tp_id,
                           user_id = item.user_id,
                           money = item.tp_totalmoney,
                           datecarete = item.tp_datecreate,
                           phone = item.User.user_phone
                       };

            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Profile()
        {
            var func = functions.CookieID();
            var list = from item in db.Users
                       where item.role_id == func.user_id
                       select new
                       {
                           id = item.user_id,
                           name = item.user_name,
                           phone = item.user_phone,
                           address = item.user_address,
                           facebook = item.user_facebook,
                           twiter = item.user_twiter,
                           instaagram = item.user_instagram,
                           email = item.user_email,
                           role = item.Role.role_name
                       };
            return Json(list, JsonRequestBehavior.AllowGet);
        }

    }
}