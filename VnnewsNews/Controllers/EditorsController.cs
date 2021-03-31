using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VnnewsNews.Controllers
{
    public class EditorsController : Controller
    {
        // GET: Editors
        //Thêm editor (Chờ duyệt nhé), duyệt xong cho qua biên tập viên
        public ActionResult Create()
        {
            return View();
        }
    }
}