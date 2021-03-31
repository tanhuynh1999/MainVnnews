using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;

namespace VnnewsNews.Controllers
{
    public class JsonController : Controller
    {
        DBvnewsEntities db = new DBvnewsEntities();
        // GET: Json
        //Danh sách tất cả tin tức bang json
        public JsonResult IndexNews()
        {
            //Làm form
            return Json(null);
        }
    }
}