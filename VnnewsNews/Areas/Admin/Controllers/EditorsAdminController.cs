using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Model.EF;

namespace VnnewsNews.Areas.Admin.Controllers
{
    public class EditorsAdminController : Controller
    {
        private DBvnewsEntities db = new DBvnewsEntities();

        // GET: Admin/EditorsAdmin
        public ActionResult Index()
        {
            var editors = db.Editors.Include(e => e.User);
            return View(editors.ToList());
        }

        // GET: Admin/EditorsAdmin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Editor editor = db.Editors.Find(id);
            if (editor == null)
            {
                return HttpNotFound();
            }
            return View(editor);
        } 
        //Duyệt 2
        public ActionResult Pass(int? id)
        {
            db.Editors.Find(id).editor_status = 2;
            db.SaveChanges();
            return Redirect(Request.UrlReferrer.ToString());
        }
        // khong duyệt 3
        public ActionResult NoPass(int? id)
        {
            db.Editors.Find(id).editor_status = 3;
            db.SaveChanges();
            return Redirect(Request.UrlReferrer.ToString());
        }
        // đang xem sét 1
        public ActionResult WatchLightning(int? id)
        {
            db.Editors.Find(id).editor_status = 1;
            db.SaveChanges();
            return Redirect(Request.UrlReferrer.ToString());
        }
        // GET: Admin/EditorsAdmin/Create
        public ActionResult Create()
        {
            ViewBag.user_id = new SelectList(db.Users, "user_id", "user_name");
            return View();
        }

        // POST: Admin/EditorsAdmin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "editor_id,editor_fullname,editor_sex,editor_fb,editor_phone,editor_time,editor_intro,editor_interests,editor_enthusiasm,user_id,editor_zalo,editor_active,editor_status")] Editor editor)
        {
            if (ModelState.IsValid)
            {
                db.Editors.Add(editor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.user_id = new SelectList(db.Users, "user_id", "user_name", editor.user_id);
            return View(editor);
        }

        // GET: Admin/EditorsAdmin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Editor editor = db.Editors.Find(id);
            if (editor == null)
            {
                return HttpNotFound();
            }
            ViewBag.user_id = new SelectList(db.Users, "user_id", "user_name", editor.user_id);
            return View(editor);
        }

        // POST: Admin/EditorsAdmin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "editor_id,editor_fullname,editor_sex,editor_fb,editor_phone,editor_time,editor_intro,editor_interests,editor_enthusiasm,user_id,editor_zalo,editor_active,editor_status")] Editor editor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(editor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.user_id = new SelectList(db.Users, "user_id", "user_name", editor.user_id);
            return View(editor);
        }

        // GET: Admin/EditorsAdmin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Editor editor = db.Editors.Find(id);
            if (editor == null)
            {
                return HttpNotFound();
            }
            return View(editor);
        }

        // POST: Admin/EditorsAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Editor editor = db.Editors.Find(id);
            db.Editors.Remove(editor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
