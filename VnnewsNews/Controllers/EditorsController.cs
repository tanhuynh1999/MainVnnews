using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using VnnewsNews.Function;
namespace VnnewsNews.Controllers
{
    public class EditorsController : Controller
    {
        FunctionsController functions = new FunctionsController();
        private DBvnewsEntities db = new DBvnewsEntities();

        // GET: Editors
        public ActionResult Index()
        {
            var editors = db.Editors.Include(e => e.User);
            return View(editors.ToList());
        }

        // GET: Editors/Details/5
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

        // GET: Editors/Create
        public ActionResult Create()
        {
            ViewBag.user_id = new SelectList(db.Users, "user_id", "user_name");
            return View();
        }

        // POST: Editors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "editor_id,editor_fullname,editor_sex,editor_fb,editor_phone,editor_time,editor_intro,editor_interests,editor_enthusiasm,user_id,editor_zalo,editor_active,editor_status")] Editor editor)
        {
            var user = functions.CookieID();
            if (ModelState.IsValid)
            {
                editor.editor_active = true;
                editor.editor_status = 1;
                editor.user_id = user.user_id;
                db.Editors.Add(editor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.user_id = new SelectList(db.Users, "user_id", "user_name", editor.user_id);
            return View(editor);
        }

        // GET: Editors/Edit/5
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

        // POST: Editors/Edit/5
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

        // GET: Editors/Delete/5
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

        // POST: Editors/Delete/5
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
