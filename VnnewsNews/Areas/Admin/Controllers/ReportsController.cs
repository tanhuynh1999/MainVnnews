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
    public class ReportsController : Controller
    {
        private DBvnewsEntities db = new DBvnewsEntities();

        // GET: Admin/Reports
        public ActionResult Index()
        {
            var reports = db.Reports.Include(r => r.News).Include(r => r.User);
            return View(reports.ToList());
        }

        // GET: Admin/Reports/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Report report = db.Reports.Find(id);
            if (report == null)
            {
                return HttpNotFound();
            }
            return View(report);
        }

        // GET: Admin/Reports/Create
        public ActionResult Create()
        {
            ViewBag.news_id = new SelectList(db.News, "vnew_id", "vnew_title");
            ViewBag.user_id = new SelectList(db.Users, "user_id", "user_name");
            return View();
        }

        // POST: Admin/Reports/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "report_id,report_content,dow_id,report_datecreate,user_id,news_id")] Report report)
        {
            if (ModelState.IsValid)
            {
                db.Reports.Add(report);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.news_id = new SelectList(db.News, "vnew_id", "vnew_title", report.news_id);
            ViewBag.user_id = new SelectList(db.Users, "user_id", "user_name", report.user_id);
            return View(report);
        }

        // GET: Admin/Reports/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Report report = db.Reports.Find(id);
            if (report == null)
            {
                return HttpNotFound();
            }
            ViewBag.news_id = new SelectList(db.News, "vnew_id", "vnew_title", report.news_id);
            ViewBag.user_id = new SelectList(db.Users, "user_id", "user_name", report.user_id);
            return View(report);
        }

        // POST: Admin/Reports/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "report_id,report_content,dow_id,report_datecreate,user_id,news_id")] Report report)
        {
            if (ModelState.IsValid)
            {
                db.Entry(report).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.news_id = new SelectList(db.News, "vnew_id", "vnew_title", report.news_id);
            ViewBag.user_id = new SelectList(db.Users, "user_id", "user_name", report.user_id);
            return View(report);
        }

        // GET: Admin/Reports/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Report report = db.Reports.Find(id);
            if (report == null)
            {
                return HttpNotFound();
            }
            return View(report);
        }

        // POST: Admin/Reports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Report report = db.Reports.Find(id);
            db.Reports.Remove(report);
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
