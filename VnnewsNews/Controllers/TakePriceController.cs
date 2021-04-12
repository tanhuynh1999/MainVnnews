using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VnnewsNews.Function;

namespace VnnewsNews.Controllers
{
    public class TakePriceController : Controller
    {
        Model.EF.DBvnewsEntities db = new Model.EF.DBvnewsEntities();
        FunctionsController func = new FunctionsController();
        // GET: TakePrice
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetMoney()
        {
            if(func.CookieID() == null)
            {
                return Redirect("/Account/Login");
            }
            return View();
        }
        [HttpPost]
        public ActionResult GetMoney(TakePrice takePrice)
        {
            if (ModelState.IsValid)
            {
                takePrice.tp_datecreate = DateTime.Now;
                takePrice.tp_active = false;
                takePrice.user_id = func.CookieID().user_id;
                db.TakePrices.Add(takePrice);
                db.SaveChanges();
                TempData["noti_takeprice"] = "Yeu cau cua ban da duoc gui vui long doi!";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}