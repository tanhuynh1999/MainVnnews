using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Model.DAO;
using VnnewsNews.Function;

namespace VnnewsNews.Controllers
{
    public class AdsController : Controller
    {
        DBvnewsEntities db = new DBvnewsEntities();
        FunctionsController functions = new FunctionsController();
        AddFileController addFile = new AddFileController();
        AdsDAO adsDAO = new AdsDAO();
        public ActionResult CreateAds()
        {
            if(functions.CookieID() == null)
            {
                return Redirect("/Account/Login");
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAds(Ad ads, HttpPostedFileBase img, string[] ads_tags, bool autocheck)
        {
            if (ModelState.IsValid)
            {
                ads.user_id = functions.CookieID().user_id;
                ads.ads_poster = addFile.UpLoadImages(img, null, "Ads");
                var tag = "";
                foreach(var item in ads_tags)
                {
                    tag += item + ";";
                }
                ads.ads_tags = tag;
                ads.ads_active = autocheck;
                adsDAO.Insert(ads);

                return RedirectToAction("Index");
            }
            return View(ads);
        }
        // GET: Ads
        [HttpPost]
        public ActionResult PostAds()
        {
            return View();
        }
        //Danh sách quản lý ads cá nhân
        public ActionResult Index()
        {
            var cookie = functions.CookieID();
            if (db.Ads.Where(t => t.user_id == cookie.user_id).Count() == 0)
            {
                return RedirectToAction("CreateAds");
            }
            return View();
        }
        
    }
}