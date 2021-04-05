using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VnnewsNews.Function
{
    public class AddFileController : Controller
    {
        // GET: AddFile
        public string UpLoadImages(HttpPostedFileBase file_img, string oldNameImage, string folder)
        {
            try
            {
                // remove old image
                if (oldNameImage != null)
                {
                    RemoveOldImages(oldNameImage, folder);
                }
                // add new image
                var img = Guid.NewGuid().ToString() + Path.GetExtension(file_img.FileName);
                var pathimg = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Images/" + folder), img);
                file_img.SaveAs(pathimg);
                return img;
            }
            catch (Exception) { return null; }
        }

        public bool RemoveOldImages(string oldNameImage, string folder)
        {
            try
            {
                string fullPath = Request.MapPath("~/Images/" + folder + "/" + oldNameImage);
                System.IO.File.Delete(fullPath);
                return true;
            }
            catch (Exception) { return false; }
        }
    }
}