using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrashCollector2.Models;

namespace TrashCollector2.Controllers
{
    public class EmployeeInfoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EmployeeInfoes
        public ActionResult Index()
        {
            var employeeInfoes = db.EmployeeInfoes.Include(e => e.User);
            return View(employeeInfoes.ToList());
        }

        //public ActionResult ConfirmPickup()
        //{
        //    string currentUserId = User.Identity.GetUserId();
        //    var currentUser = db.Users.FirstOrDefault(x => x.Id == currentUserId);
        //    var currentCustomer = db.CustomerInfoes.Where(c => c.UserId.Equals(currentUser.Id)).Single();

        //    currentCustomer.Schedule.PickupStatus = "Complete";
        //    currentCustomer.Invoice.AmountDue = 55;
        //    return View();
        //}

        // GET: EmployeeInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeInfo employeeInfo = db.EmployeeInfoes.Find(id);
            if (employeeInfo == null)
            {
                return HttpNotFound();
            }
            return View(employeeInfo);
        }

        // GET: EmployeeInfoes/Create
        public ActionResult Create()
        {
            //ViewBag.UserId = new SelectList(db.ApplicationUsers, "Id", "Email");
            return View();
        }

        // POST: EmployeeInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserId,FirstName,LastName,ZipCode")] EmployeeInfo employeeInfo)
        {
            if (ModelState.IsValid)
            {
                employeeInfo.UserId = User.Identity.GetUserId();
                db.EmployeeInfoes.Add(employeeInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.UserId = new SelectList(db.ApplicationUsers, "Id", "Email", employeeInfo.UserId);
            return View(employeeInfo);
        }

        // GET: EmployeeInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeInfo employeeInfo = db.EmployeeInfoes.Find(id);
            if (employeeInfo == null)
            {
                return HttpNotFound();
            }
            //ViewBag.UserId = new SelectList(db.ApplicationUsers, "Id", "Email", employeeInfo.UserId);
            return View(employeeInfo);
        }

        // POST: EmployeeInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserId,FirstName,LastName,ZipCode")] EmployeeInfo employeeInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.UserId = new SelectList(db.ApplicationUsers, "Id", "Email", employeeInfo.UserId);
            return View(employeeInfo);
        }

        // GET: EmployeeInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeInfo employeeInfo = db.EmployeeInfoes.Find(id);
            if (employeeInfo == null)
            {
                return HttpNotFound();
            }
            return View(employeeInfo);
        }

        // POST: EmployeeInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeInfo employeeInfo = db.EmployeeInfoes.Find(id);
            db.EmployeeInfoes.Remove(employeeInfo);
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
