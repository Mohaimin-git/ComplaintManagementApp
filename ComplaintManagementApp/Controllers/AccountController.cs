using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ComplaintManagementApp;

namespace ComplaintManagementApp.Controllers
{
    public class AccountController : Controller
    {
        private ComplaintDataBaseEntities db = new ComplaintDataBaseEntities();

        // GET: Account
        public ActionResult Index()
        {
            return View(db.UserInfo_tbl.ToList());
        }

        // GET: Account/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserInfo_tbl userInfo_tbl = db.UserInfo_tbl.Find(id);
            if (userInfo_tbl == null)
            {
                return HttpNotFound();
            }
            return View(userInfo_tbl);
        }

        // GET: Account/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Account/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,Name,Password,Email")] UserInfo_tbl userInfo_tbl)
        {
            if (ModelState.IsValid)
            {
                db.UserInfo_tbl.Add(userInfo_tbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userInfo_tbl);
        }

        // GET: Account/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserInfo_tbl userInfo_tbl = db.UserInfo_tbl.Find(id);
            if (userInfo_tbl == null)
            {
                return HttpNotFound();
            }
            return View(userInfo_tbl);
        }

        // POST: Account/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,Name,Password,Email")] UserInfo_tbl userInfo_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userInfo_tbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userInfo_tbl);
        }

        // GET: Account/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserInfo_tbl userInfo_tbl = db.UserInfo_tbl.Find(id);
            if (userInfo_tbl == null)
            {
                return HttpNotFound();
            }
            return View(userInfo_tbl);
        }

        // POST: Account/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserInfo_tbl userInfo_tbl = db.UserInfo_tbl.Find(id);
            db.UserInfo_tbl.Remove(userInfo_tbl);
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
