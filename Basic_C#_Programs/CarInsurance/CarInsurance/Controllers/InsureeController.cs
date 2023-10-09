using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarInsurance.Models;

namespace CarInsurance.Controllers
{
    public class InsureeController : Controller
    {
        private InsuranceEntities db = new InsuranceEntities();
        private decimal getQuote(DateTime dateOfBirth, int carYear, string carMake, string carModel, int speedingTickets, bool DUI, bool CoverageType)
        {
            decimal quote = 50m;
            int age = ( DateTime.Now.Year- dateOfBirth.Year);
            //age considerations
            if (age <= 18)
            {
                quote += 100;
            }
            else if (age <= 25)
            {
                quote += 50;
            }
            else
            {
                quote += 25;
            }
            //carYear considerations.
            if (carYear < 200)
            {
                quote += 25;
            }
            else if (carYear > 2015)
            {
                quote += 25;
            }
            if (carMake.ToLower() == "porsche")
            {
                quote += 25;
                if (carModel.ToLower() == "911 Carrera")
                {
                    quote += 25;
                }
            }
            quote += (10 * speedingTickets);
            if (DUI)
            {
                quote += quote * 0.25m;
            }
            if (CoverageType)
            {
                quote += quote * 0.5m;
            }
            return quote;

        }
        // GET: Insuree
        public ActionResult Index()
        {
            return View(db.Insurees1.ToList());
        }
        // GET: Insuree/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insuree insuree = db.Insurees1.Find(id);
            if (insuree == null)
            {
                return HttpNotFound();
            }
            return View(insuree);
        }

        // GET: Insuree/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Insuree/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,EmailAddress,DateOfBirth,CarYear,CarMake,CarModel,DUI,SpeedingTickets,CoverageType")] Insuree insuree)
        {

            insuree.Quote = getQuote(insuree.DateOfBirth, insuree.CarYear, insuree.CarMake, insuree.CarModel, insuree.SpeedingTickets, insuree.DUI, insuree.CoverageType);
            if (ModelState.IsValid)
            {
                db.Insurees1.Add(insuree);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(insuree);
        }

        // GET: Insuree/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insuree insuree = db.Insurees1.Find(id);
            if (insuree == null)
            {
                return HttpNotFound();
            }
            return View(insuree);
        }

        // POST: Insuree/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,EmailAddress,DateOfBirth,CarYear,CarMake,CarModel,DUI,SpeedingTickets,CoverageType")] Insuree insuree)
        {
            insuree.Quote = getQuote(insuree.DateOfBirth, insuree.CarYear, insuree.CarMake, insuree.CarModel, insuree.SpeedingTickets, insuree.DUI, insuree.CoverageType);
            if (ModelState.IsValid)
            {
                db.Entry(insuree).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(insuree);
        }

        // GET: Insuree/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insuree insuree = db.Insurees1.Find(id);
            if (insuree == null)
            {
                return HttpNotFound();
            }
            return View(insuree);
        }

        // POST: Insuree/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Insuree insuree = db.Insurees1.Find(id);
            db.Insurees1.Remove(insuree);
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
