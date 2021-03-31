using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;

namespace VnnewsNews.Controllers
{
    public class AdsController : Controller
    {
        public ActionResult CreateAds()
        {
            return View();
        }
        // GET: Ads
        [HttpPost]
        public ActionResult PostAds()
        {
            return View();
        }
    }
}