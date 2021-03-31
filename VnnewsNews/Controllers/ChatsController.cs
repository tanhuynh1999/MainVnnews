using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VnnewsNews.Controllers
{
    public class ChatsController : Controller
    {
        // GET: Chats
        public ActionResult ChatAll()
        {
            return View();
        }
    }
}