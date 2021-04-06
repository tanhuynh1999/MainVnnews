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
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAds(Ad ads, HttpPostedFileBase img, string[] ads_tag, bool autocheck = true)
        {
            ads.user_id = functions.CookieID().user_id;
            ads.ads_poster = addFile.UpLoadImages(img, null, "Ads");
            var tag = "";
            if(ads_tag != null)
            {
                foreach (var item in ads_tag)
                {
                    tag += item + ";";
                }
            }
            ads.ads_tags = tag;
            ads.ads_active = autocheck;
            adsDAO.Insert(ads);

            return RedirectToAction("Index");
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
            if(cookie == null)
            {
                return Redirect("/Account/Login");
            }
            if (db.Ads.Where(t => t.user_id == cookie.user_id).Count() == 0)
            {
                return RedirectToAction("CreateAds");
            }
            return View();
        }
        
    }
}