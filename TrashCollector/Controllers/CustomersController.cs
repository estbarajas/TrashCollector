using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Customers
        public ActionResult Index()
        {
            return View(db.Customers.ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer Customer = db.Customers.Find(id);
            if (Customer == null)
            {
                return HttpNotFound();
            }
            return View(Customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName")] Customer Customer)
        {
            //var all = from c in db.Customers select c;
            //db.Customers.RemoveRange(all);
            //db.SaveChanges();
            if (ModelState.IsValid)
            {

                Schedule schedule = new Schedule();
                Invoice invoice = new Invoice();
                db.Schedules.Add(schedule);
                db.Invoices.Add(invoice);

                var theCustomer = Customer;

                theCustomer.InvoiceId = invoice.Id;
                theCustomer.ScheduleId = schedule.Id;
                //theCustomer.UserId =


                db.Customers.Add(theCustomer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(Customer);
            //return View();
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer Customer = db.Customers.Find(id);
            if (Customer == null)
            {
                return HttpNotFound();
            }
            return View(Customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName")] Customer Customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer Customer = db.Customers.Find(id);
            if (Customer == null)
            {
                return HttpNotFound();
            }
            return View(Customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer Customer = db.Customers.Find(id);
            db.Customers.Remove(Customer);
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
