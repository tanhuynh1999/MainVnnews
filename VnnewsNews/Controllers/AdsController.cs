using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Model.DAO;
using VnnewsNews.Function;
using System.Drawing;
using Google.Cloud.Vision.V1;
using Image = Google.Cloud.Vision.V1.Image;

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
            foreach(var item in db.BadWords)
            {
                if (ads.ads_title.ToLower().Contains(item.bw_name.ToLower()))
                {
                    TempData["noti_create_ads"] = "Từ ngữ không hợp lệ!";
                    return View(ads);
                }
            }

            var coo = new FunctionsController();
            var idus = coo.CookieID();

            ads.user_id = functions.CookieID().user_id;
            ads.ads_poster = addFile.UpLoadImages(img, null, "Ads");

            // kiem tra anh ko lanh manh
            //Image image = Google.Cloud.Vision.V1.Image.FromFile(Request.MapPath("~/Images/Ads/" + ads.ads_poster));
            //ImageAnnotatorClient client = ImageAnnotatorClient.Create();
            //SafeSearchAnnotation annotation = client.DetectSafeSearch(image);
            //var a = ($"Adult? {annotation.Adult}");
            //var b = ($"Spoof? {annotation.Spoof}");
            //var c = ($"Violence? {annotation.Violence}");
            //var d = ($"Medical? {annotation.Medical}");

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

            Ad ad = db.Ads.Where(n => n.user_id == idus.user_id).OrderByDescending(n => n.ads_datecreate).First();



            return Redirect("/Pays/PayMoMo?id="+ad.ads_id);
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