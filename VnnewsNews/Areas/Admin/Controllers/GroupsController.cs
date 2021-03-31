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
    public class GroupsController : Controller
    {
        private DBvnewsEntities db = new DBvnewsEntities();

        // GET: Admin/Groups
        public ActionResult Index()
        {
            var groups = db.Groups.Include(g => g.Category).Include(g => g.User);
            return View(groups.ToList());
        }

        // GET: Admin/Groups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = db.Groups.Find(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

        // GET: Admin/Groups/Create
        public ActionResult Create()
        {
            ViewBag.category_id = new SelectList(db.Categorys, "category_id", "category_name");
            ViewBag.user_id = new SelectList(db.Users, "user_id", "user_name");
            return View();
        }

        // POST: Admin/Groups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "group_id,news_id,user_id,group_item,group_datecreate,category_id")] Group group)
        {
            if (ModelState.IsValid)
            {
                db.Groups.Add(group);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.category_id = new SelectList(db.Categorys, "category_id", "category_name", group.category_id);
            ViewBag.user_id = new SelectList(db.Users, "user_id", "user_name", group.user_id);
            return View(group);
        }

        // GET: Admin/Groups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = db.Groups.Find(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            ViewBag.category_id = new SelectList(db.Categorys, "category_id", "category_name", group.category_id);
            ViewBag.user_id = new SelectList(db.Users, "user_id", "user_name", group.user_id);
            return View(group);
        }

        // POST: Admin/Groups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "group_id,news_id,user_id,group_item,group_datecreate,category_id")] Group group)
        {
            if (ModelState.IsValid)
            {
                db.Entry(group).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.category_id = new SelectList(db.Categorys, "category_id", "category_name", group.category_id);
            ViewBag.user_id = new SelectList(db.Users, "user_id", "user_name", group.user_id);
            return View(group);
        }

        // GET: Admin/Groups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = db.Groups.Find(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

        // POST: Admin/Groups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Group group = db.Groups.Find(id);
            db.Groups.Remove(group);
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
