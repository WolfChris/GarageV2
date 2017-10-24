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


        //VehicleTypeModel model = new VehicleTypeModel();
        //model.VehicleList.Add(new SelectListItem { Text = "Car", Value = "1" });
        //model.VehicleList.Add(new SelectListItem { Text = "Motorcycle", Value = "2" });
        //model.VehicleList.Add(new SelectListItem { Text = "Airplane", Value = "3" });
        //model.VehicleList.Add(new SelectListItem { Text = "Boat", Value = "4" });

        //public ActionResult Index()
        //{
        //    SubjectModel model = new SubjectModel();
        //    model.SubjectList.Add(new SelectListItem { Text = "Physics", Value = "1" });
        //    model.SubjectList.Add(new SelectListItem { Text = "Chemistry", Value = "2" });
        //    model.SubjectList.Add(new SelectListItem { Text = "Mathematics", Value = "3" });
        //    return View(model);
        //}

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
        public ActionResult CheckIn([Bind(Include = "Id,Type,RegNo,Color,Brand,Modell,NumberOfWheels")] ParkedVehicle parkedVehicle)
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
        public ActionResult Create([Bind(Include = "Id,Type,RegNo,Color,Brand,Modell,NumberOfWheels")] ParkedVehicle parkedVehicle)
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

        // POST: ParkedVehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Type,RegNo,Color,Brand,Modell,NumberOfWheels")] ParkedVehicle parkedVehicle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parkedVehicle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(parkedVehicle);
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
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ParkedVehicle parkedVehicle = db.ParkedVehicle.Find(id);
            db.ParkedVehicle.Remove(parkedVehicle);
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
