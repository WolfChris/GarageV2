using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GarageV2.DataAccessLayer;
using GarageV2.Models;

namespace GarageV2.Controllers
{
    public class ParkedVehiclesController : Controller
    {
        private double pricePerHour = 13.5;
        private ParkedVehicleContext db = new ParkedVehicleContext();
        
        // GET: ParkedVehicles
        public ActionResult Index()
        {
            return View(db.ParkedVehicle.ToList());
        }

        public ActionResult CheckIn()
        {
            return View();
        }

        public ActionResult Overview()
        {
            var dbParkedVehicles = db.ParkedVehicle;
            List<ParkedVehicle> parkedVehicles = dbParkedVehicles.ToList();
            
            var vehicles = parkedVehicles
                .Select(v => new GarageV2.ViewModels.OverviewViewModel
                {
                    Id = v.Id,
                    RegNo = v.RegNo,
                    Type = v.Type.ToString(),
                    Color = v.Color
                })
                .ToList();

            return View(vehicles);
        }

        public ActionResult CheckOut(int? id)
        {
            ViewBag.checkedOut = false;

            if (id != null)
            {
                ParkedVehicle vehicleDetail = db.ParkedVehicle.FirstOrDefault(v => v.Id == id);
                if (vehicleDetail == null)
                {
                    return HttpNotFound();
                }
                return View(vehicleDetail);
            }
            return View();
        }

        // GET: VehicleDetails/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CheckOut(string RegNo)
        {
            ViewBag.checkedOut = false;

            if (RegNo.Equals(null))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkedVehicle vehicleDetail = db.ParkedVehicle.FirstOrDefault(v => v.RegNo == RegNo);
            if (vehicleDetail == null)
            {
                return HttpNotFound();
            }
            return View(vehicleDetail);
        }

        // POST: VehicleDetails/Delete/5
        [HttpPost, ActionName("CheckOutConfirmed")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed2(string RegNo)
        {

            ParkedVehicle vehicleDetail = db.ParkedVehicle.FirstOrDefault(v => v.RegNo == RegNo);
            db.ParkedVehicle.Remove(vehicleDetail);
            db.SaveChanges();
            vehicleDetail.CheckOutTime = DateTime.Now;
            ViewBag.checkedOut = true;
            return View("CheckOut",vehicleDetail);
        }


        // GET: ParkedVehicles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkedVehicle parkedVehicle = db.ParkedVehicle.Find(id);
            if (parkedVehicle == null)
            {
                return HttpNotFound();
            }
            return View(parkedVehicle);
        }

        // GET: ParkedVehicles/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CheckIn([Bind(Include = "Id,Type,RegNo,Color,Brand,Model,NumberOfWheels")] ParkedVehicle parkedVehicle)
        {
            if (ModelState.IsValid)
            {
                db.ParkedVehicle.Add(parkedVehicle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(parkedVehicle);
        }

        // POST: ParkedVehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Type,RegNo,Color,Brand,Model,NumberOfWheels")] ParkedVehicle parkedVehicle)
        {
            if (ModelState.IsValid)
            {
                db.ParkedVehicle.Add(parkedVehicle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(parkedVehicle);
        }

        // GET: ParkedVehicles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkedVehicle parkedVehicle = db.ParkedVehicle.Find(id);
            if (parkedVehicle == null)
            {
                return HttpNotFound();
            }
            return View(parkedVehicle);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var vehicleToUpdate = db.ParkedVehicle.Find(id);
            if (TryUpdateModel(vehicleToUpdate, "",
               new string[] { "Id","Type","RegNo","Color","Brand","Model","NumberOfWheels" }))
            {
                try
                {
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (DataException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            return View(vehicleToUpdate);
        }
      
        // GET: ParkedVehicles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkedVehicle parkedVehicle = db.ParkedVehicle.Find(id);
            if (parkedVehicle == null)
            {
                return HttpNotFound();
            }
            return View(parkedVehicle);
        }

        // POST: ParkedVehicles/Delete/5
        [HttpPost, ActionName("delete123")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ParkedVehicle parkedVehicle = db.ParkedVehicle.Find(id);
            db.ParkedVehicle.Remove(parkedVehicle);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Receipt(ParkedVehicle checkedOutVehicle)
        {
            var receiptVehicle = new ViewModels.ReceiptViewModel(checkedOutVehicle);
            receiptVehicle.TotalPrice = TotalPrice(receiptVehicle.CheckInTime, (DateTime)receiptVehicle.CheckOutTime);

            return View(receiptVehicle);
        }

        private double TotalPrice(DateTime checkInTime, DateTime checkOutTime)
        {
            var totalParkedTime = checkOutTime - checkInTime;
            double totalParkedHours = ((TimeSpan)totalParkedTime).TotalHours;

            int startedHours = (int)Math.Ceiling(totalParkedHours);

            return startedHours * pricePerHour;
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
