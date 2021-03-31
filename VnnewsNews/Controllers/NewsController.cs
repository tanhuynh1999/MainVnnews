
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
    }
}