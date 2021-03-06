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
    public class UserController : Controller
    {
        private ComplaintDataBaseEntities db = new ComplaintDataBaseEntities();

        // GET: User
        public ActionResult Index()
        {
            return View(db.User_tbl.ToList());
        }

        //to get login view
        public ActionResult LoginPage()
        {
            return View();
        }
        //pass and name sent to this action
        [HttpPost]
        public ActionResult Authorize(ComplaintManagementApp.User_tbl userModel)
        {
            using (ComplaintDataBaseEntities db = new ComplaintDataBaseEntities())
            {
                var userDetails = db.User_tbl.Where(x => x.Username == userModel.Username && x.Password == userModel.Password).FirstOrDefault();
                if (userDetails == null)
                {
                    ViewBag.loginError = "Username or Password is incorrect";
                    return View("LoginPage", userModel);
                }
                else

                {
                    Session["userId"] = userDetails.Id;  //POCHO
                    if(userDetails.Role == "Admin")
                    {
                        return RedirectToAction("Index", "Home"); //DASHBOARD NAME 38:41

                    }
                    else
                    {
                        return RedirectToAction("homepage", "Home"); //DASHBOARD NAME 38:41

                    }
                }
            }

        }

        // GET: User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_tbl user_tbl = db.User_tbl.Find(id);
            if (user_tbl == null)
            {
                return HttpNotFound();
            }
            return View(user_tbl);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Username,Email,Password,CPassword,Role")] User_tbl user_tbl)
        {
            if (ModelState.IsValid)
            {   
                db.User_tbl.Add(user_tbl);
                db.SaveChanges();
                return RedirectToAction("LoginPage","User");   //put login page here
            }

            return View(user_tbl);
        }

        // GET: User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_tbl user_tbl = db.User_tbl.Find(id);
            if (user_tbl == null)
            {
                return HttpNotFound();
            }
            return View(user_tbl);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Username,Email,Password,Role")] User_tbl user_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user_tbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user_tbl);
        }

        // GET: User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_tbl user_tbl = db.User_tbl.Find(id);
            if (user_tbl == null)
            {
                return HttpNotFound();
            }
            return View(user_tbl);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User_tbl user_tbl = db.User_tbl.Find(id);
            db.User_tbl.Remove(user_tbl);
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
        public ActionResult Logout()
        {
            Session.Clear();
            //Session.RemoveAll();
            //Session["userId"] = null;

            return RedirectToAction("LoginPage","User");
        }

    }
}
