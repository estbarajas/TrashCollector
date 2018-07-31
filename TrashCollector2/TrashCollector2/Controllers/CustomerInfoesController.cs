﻿using Microsoft.AspNet.Identity;
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
    public class CustomerInfoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public UserManager<ApplicationUser> userManager;

        // GET: CustomerInfoes
        public ActionResult Index()
        {
            var customerInfoes = db.CustomerInfoes.Include(c => c.Invoice).Include(c => c.Schedule);
            return View(customerInfoes.ToList());
        }

        // GET: CustomerInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerInfo customerInfo = db.CustomerInfoes.Find(id);
            if (customerInfo == null)
            {
                return HttpNotFound();
            }
            return View(customerInfo);
        }

        // GET: CustomerInfoes/Create
        public ActionResult Create()
        {
            ViewBag.InvoiceId = new SelectList(db.Invoices, "Id", "Status");
            ViewBag.ScheduleId = new SelectList(db.Schedules, "Id", "NormalDayPickUp");
            return View();
        }

        // POST: CustomerInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName,Address,ZipCode,ScheduleId,InvoiceId")] CustomerInfo customerInfo)
        {
            //var all = from c in db.CustomerInfoes select c;
            //db.CustomerInfoes.RemoveRange(all);
            //db.SaveChanges();

            if (ModelState.IsValid)
            {
                Schedule schedule = new Schedule();
                Invoice invoice = new Invoice();

                string currentUserId = User.Identity.GetUserId();
                ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id == currentUserId);

                db.Schedules.Add(schedule);
                db.Invoices.Add(invoice);

                var theCustomer = customerInfo;

                theCustomer.InvoiceId = invoice.Id;
                theCustomer.ScheduleId = schedule.Id;
                theCustomer.UserId = currentUser.Id;

                db.CustomerInfoes.Add(theCustomer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.InvoiceId = new SelectList(db.Invoices, "Id", "Status", customerInfo.InvoiceId);
            //ViewBag.ScheduleId = new SelectList(db.Schedules, "Id", "NormalDayPickUp", customerInfo.ScheduleId);
            return View("CustomerInfoes");
        }

        // GET: CustomerInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerInfo customerInfo = db.CustomerInfoes.Find(id);
            if (customerInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.InvoiceId = new SelectList(db.Invoices, "Id", "Status", customerInfo.InvoiceId);
            ViewBag.ScheduleId = new SelectList(db.Schedules, "Id", "NormalDayPickUp", customerInfo.ScheduleId);
            return View(customerInfo);
        }

        // POST: CustomerInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName,Address,ZipCode,ScheduleId,InvoiceId")] CustomerInfo customerInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InvoiceId = new SelectList(db.Invoices, "Id", "Status", customerInfo.InvoiceId);
            ViewBag.ScheduleId = new SelectList(db.Schedules, "Id", "NormalDayPickUp", customerInfo.ScheduleId);
            return View(customerInfo);
        }

        // GET: CustomerInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerInfo customerInfo = db.CustomerInfoes.Find(id);
            if (customerInfo == null)
            {
                return HttpNotFound();
            }
            return View(customerInfo);
        }

        // POST: CustomerInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomerInfo customerInfo = db.CustomerInfoes.Find(id);
            db.CustomerInfoes.Remove(customerInfo);
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