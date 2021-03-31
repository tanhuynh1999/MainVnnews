using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VnnewsNews.Areas.Admin.Controllers
{
    public class ViewAdminController : Controller
    {
        // GET: Admin/ViewAdmin
        public PartialViewResult Menu()
        {
            return PartialView();
        }
    }
}