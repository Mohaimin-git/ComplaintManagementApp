using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ComplaintManagementApp;
/// <summary>
/// ///ooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo
/// </summary>
namespace ComplaintManagementApp.Controllers
{
    public class HomeController : Controller
    {
        private ComplaintDataBaseEntities db = new ComplaintDataBaseEntities();

        // GET: Home
        public ActionResult Index()
        {
            return View(db.Complaint_tbl.ToList());
        }

        // GET: Home/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Complaint_tbl complaint_tbl = db.Complaint_tbl.Find(id);
            if (complaint_tbl == null)
            {
                return HttpNotFound();
            }
            return View(complaint_tbl);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ComplaintId,Complaint_Title,Discription,Date,Status,UpdateOn")] Complaint_tbl complaint_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Complaint_tbl.Add(complaint_tbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(complaint_tbl);
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Complaint_tbl complaint_tbl = db.Complaint_tbl.Find(id);
            if (complaint_tbl == null)
            {
                return HttpNotFound();
            }
            return View(complaint_tbl);
        }

        // POST: Home/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ComplaintId,Complaint_Title,Discription,Date,Status,UpdateOn")] Complaint_tbl complaint_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(complaint_tbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(complaint_tbl);
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Complaint_tbl complaint_tbl = db.Complaint_tbl.Find(id);
            if (complaint_tbl == null)
            {
                return HttpNotFound();
            }
            return View(complaint_tbl);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Complaint_tbl complaint_tbl = db.Complaint_tbl.Find(id);
            db.Complaint_tbl.Remove(complaint_tbl);
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
        public ActionResult homepage()
        {
            return View();
        }
    }
}
