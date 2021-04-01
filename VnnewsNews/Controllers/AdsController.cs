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
        public ActionResult CreateAds()
        {
            if(functions.CookieID() == null)
            {
                return Redirect("/Account/Login");
            }
            return View();
        }
        [HttpPost]
        public ActionResult CreateAds(Ad ads)
        {
            if (ModelState.IsValid)
            {
                
            }
            return View();
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