using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VnnewsNews.Areas.Admin.Controllers
{
    public class ShareViewAdminController : Controller
    {
        // GET: Admin/ShareViewAdmin
        public PartialViewResult Panel()
        {
            return PartialView();
        }
        public PartialViewResult Menu()
        {
            return PartialView();
        }
    }
}