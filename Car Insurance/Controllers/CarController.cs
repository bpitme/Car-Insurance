using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Car_Insurance.Models;

namespace Car_Insurance.Controllers
{
    public class CarController : Controller
    {
        private Entities1 db = new Entities1();

        // GET: Car
        public ActionResult Index()
        {
            return View(db.Car_Registrations.ToList());
        }

        // GET: Car/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car_Registration car_Registration = db.Car_Registrations.Find(id);
            if (car_Registration == null)
            {
                return HttpNotFound();
            }
            return View(car_Registration);
        }

        // GET: Car/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Car/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CarYear,CarMake,CarModel,DUL,SpeedingTickets,CoverageType,Quote")] Car_Registration car_Registration)
        {
            if (ModelState.IsValid)
            {
                db.Car_Registrations.Add(car_Registration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(car_Registration);
        }

        // GET: Car/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car_Registration car_Registration = db.Car_Registrations.Find(id);
            if (car_Registration == null)
            {
                return HttpNotFound();
            }
            return View(car_Registration);
        }

        // POST: Car/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CarYear,CarMake,CarModel,DUL,SpeedingTickets,CoverageType,Quote")] Car_Registration car_Registration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(car_Registration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(car_Registration);
        }

        // GET: Car/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car_Registration car_Registration = db.Car_Registrations.Find(id);
            if (car_Registration == null)
            {
                return HttpNotFound();
            }
            return View(car_Registration);
        }

        // POST: Car/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Car_Registration car_Registration = db.Car_Registrations.Find(id);
            db.Car_Registrations.Remove(car_Registration);
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
