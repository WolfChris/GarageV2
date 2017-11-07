using GarageV2.DataAccessLayer;
using GarageV2.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace GarageV2.Controllers
{
    public class ParkedVehiclesController : Controller
    {
        private ParkedVehicleContext db = new ParkedVehicleContext();

        public ActionResult Index()
        {
            return RedirectToAction("Overview");
        }

        #region CheckIn

        public ActionResult CheckIn(int? id)
        {
            var checkInViewModel = new ViewModels.CheckInViewModel();
            checkInViewModel.Members = db.Member.ToList().Select(v => new SelectListItem
            {
                Selected = (v.Id == id),
                Value = v.Id.ToString(),
                Text = v.FullName
            });

            checkInViewModel.VehicleTypes = db.VehicleType.ToList().Select(v => new SelectListItem
            {
                Value = v.Id.ToString(),
                Text = v.Name
            });

            if (id != null) { checkInViewModel.MemberId = (int)id; }
            return View(checkInViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CheckIn([Bind(Include = "Id,VehicleTypeId,MemberId,RegNo,Color,Brand,Model,NumberOfWheels")] ParkedVehicle newVehicle)
        {
            ParkedVehicle alreadyParkedVehicle = db.ParkedVehicle.FirstOrDefault(v => v.RegNo == newVehicle.RegNo);
            if (alreadyParkedVehicle != null)
            {
                ModelState.AddModelError(string.Empty, $"Fordon med registreringsnummer {newVehicle.RegNo} är redan incheckat");
            }


            if (ModelState.IsValid)
            {
                db.ParkedVehicle.Add(newVehicle);
                db.SaveChanges();

                var parkedVehicle = db.ParkedVehicle.Include(v => v.Member).Include(v => v.VehicleType).FirstOrDefault(v => v.Id == newVehicle.Id);

                return View("CheckInConfirmed", parkedVehicle);
            }

            var checkInViewModel = new ViewModels.CheckInViewModel(newVehicle);
            checkInViewModel.Members = db.Member.ToList().Select(v => new SelectListItem
            {
                Selected = (v.Id == checkInViewModel.MemberId),
                Value = v.Id.ToString(),
                Text = v.FullName
            });

            checkInViewModel.VehicleTypes = db.VehicleType.ToList().Select(v => new SelectListItem
            {
                Selected = (v.Id == checkInViewModel.VehicleTypeId),
                Value = v.Id.ToString(),
                Text = v.Name
            });
            return View(checkInViewModel);
        }
        #endregion

        #region CheckOut

        public ActionResult CheckOut(int? id)
        {
            ViewBag.AskForRegNo = true;
            ViewBag.ConfirmedCheckOut = false;
            ViewBag.checkedOut = false;

            if (id != null)
            {
                ParkedVehicle vehicleDetail = db.ParkedVehicle.FirstOrDefault(v => v.Id == id);
                if (vehicleDetail == null)
                {
                    return HttpNotFound();
                }
                var checkOutViewModel = new ViewModels.CheckOutViewModel(vehicleDetail);
                return View(checkOutViewModel);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CheckOut(string RegNo)
        {
            if (RegNo.Equals(null))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkedVehicle vehicleDetail = db.ParkedVehicle.FirstOrDefault(v => v.RegNo == RegNo);

            if (vehicleDetail == null)
            {
                ModelState.AddModelError("RegNo", "Registreringsnumret hittades inte");
            }
            if (ModelState.IsValid)
            {
                ViewBag.AskForRegNo = false;
                ViewBag.ConfirmedCheckOut = true;
                ViewBag.checkedOut = false;
                var checkOutViewModel = new ViewModels.CheckOutViewModel(vehicleDetail);
                return View(checkOutViewModel);
            }
            ViewBag.AskForRegNo = true;
            ViewBag.ConfirmedCheckOut = false;
            ViewBag.checkedOut = false;
            return View("CheckOut");
        }

        public ActionResult ConfirmCheckOut(int id)
        {
            ParkedVehicle vehicleDetail = db.ParkedVehicle.FirstOrDefault(v => v.Id == id);
            double pricePerHour = db.Garage.FirstOrDefault().PricePerHour;
            vehicleDetail.TotalPrice = TotalPrice(vehicleDetail.CheckInTime, DateTime.Now, pricePerHour);

            if (vehicleDetail == null)
            {
                ModelState.AddModelError("RegNo", "Registreringsnumret hittades inte");
            }
            if (ModelState.IsValid)
            {
                ViewBag.AskForRegNo = false;
                ViewBag.ConfirmedCheckOut = true;
                ViewBag.checkedOut = false;

                var checkOutViewModel = new ViewModels.CheckOutViewModel(vehicleDetail);
                return View("CheckOut", checkOutViewModel);
            }
            ViewBag.AskForRegNo = true;
            ViewBag.ConfirmedCheckOut = false;
            ViewBag.checkedOut = false;
            return View("CheckOut");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CheckOutConfirmed(int id)//string RegNo)
        {
            ViewBag.AskForRegNo = false;

            ParkedVehicle vehicleDetail = db.ParkedVehicle.FirstOrDefault(v => v.Id == id);

            vehicleDetail.CheckOutTime = DateTime.Now;
            double pricePerHour = db.Garage.FirstOrDefault().PricePerHour;
            vehicleDetail.TotalPrice = TotalPrice(vehicleDetail.CheckInTime, (DateTime)vehicleDetail.CheckOutTime, pricePerHour);
            var checkOutViewModel = new ViewModels.CheckOutViewModel(vehicleDetail);

            db.ParkedVehicle.Remove(vehicleDetail);
            db.SaveChanges();

            ViewBag.checkedOut = true;
            return View("CheckOut", checkOutViewModel);
        }

        #endregion

        #region Overview, Details, Edit    

        public ActionResult DetailedOverview(string searchBy, string search)
        {
            List<ParkedVehicle> parkedVehicles = db.ParkedVehicle.ToList();


            if (searchBy == "VehicleType")
            {
                var vehicleType = parkedVehicles.Where(v => v.VehicleType.Name.ToLower().Contains(search.ToLower())).
                Select(v => new GarageV2.ViewModels.DetailedOverviewViewModel(v, db.Garage.FirstOrDefault().PricePerHour)).ToList();

                return View(vehicleType);
            }

            if (searchBy == "VehicleTypexx")
            {
                var vehicleType = parkedVehicles.Where(v => v.VehicleType.Name.ToLower().Contains(search.ToLower())).
                Select(v => new GarageV2.ViewModels.DetailedOverviewViewModel(v, db.Garage.FirstOrDefault().PricePerHour)).ToList();

                return View(vehicleType);
            }

            if (searchBy == "RegNo")
            {
                var vehiclesRegNo = parkedVehicles.Where(v => v.RegNo.ToLower().Contains(search.ToLower()))
                .Select(v => new GarageV2.ViewModels.DetailedOverviewViewModel(v, db.Garage.FirstOrDefault().PricePerHour)).ToList();

                return View(vehiclesRegNo);
            }

            if (searchBy == "Color")
            {
                var vehiclesColor = parkedVehicles.Where(v => (v.Color ?? "").ToLower().Contains(search.ToLower()))
                .Select(v => new GarageV2.ViewModels.DetailedOverviewViewModel(v, db.Garage.FirstOrDefault().PricePerHour)).ToList();

                return View(vehiclesColor);
            }

            if (searchBy == "Owner")
            {
                var vehiclesColor = parkedVehicles.Where(v => (v.Member.FullName.ToLower() ?? "").Contains(search.ToLower()))
                .Select(v => new GarageV2.ViewModels.DetailedOverviewViewModel(v, db.Garage.FirstOrDefault().PricePerHour)).ToList();

                return View(vehiclesColor);
            }

            var vehicles = parkedVehicles
                .Select(v => new GarageV2.ViewModels.DetailedOverviewViewModel(v, db.Garage.FirstOrDefault().PricePerHour)).ToList();

            return View(vehicles);

        }

        public ActionResult Overview(string searchBy, string search)
        {
            var dbParkedVehicles = db.ParkedVehicle;
            List<ParkedVehicle> parkedVehicles = dbParkedVehicles.ToList();

            if (searchBy == "VehicleType")
            {
                var vehicleType = parkedVehicles.Where(v => v.VehicleType.Name.ToLower().Contains(search.ToLower()))
                .Select(v => new GarageV2.ViewModels.OverviewViewModel(v)).ToList();

                return View(vehicleType);
            }

            if (searchBy == "RegNo")
            {
                var vehiclesRegNo = parkedVehicles.Where(v => v.RegNo.ToLower().Contains(search.ToLower()))
                .Select(v => new GarageV2.ViewModels.OverviewViewModel(v)).ToList();

                return View(vehiclesRegNo);
            }

            if (searchBy == "Owner")
            {
                var vehiclesColor = parkedVehicles.Where(v => (v.Member.FullName.ToLower() ?? "").Contains(search.ToLower()))
                .Select(v => new GarageV2.ViewModels.OverviewViewModel(v)).ToList();

                return View(vehiclesColor);
            }

            var vehicles = parkedVehicles
                .Select(v => new GarageV2.ViewModels.OverviewViewModel(v)).ToList();

            return View(vehicles);
        }

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

            var vehicle = new GarageV2.ViewModels.DetailsViewModel(parkedVehicle);
            double pricePerHour = db.Garage.FirstOrDefault().PricePerHour;

            var currentTime = DateTime.Now;
            vehicle.TotalPrice = TotalPriceString(vehicle.CheckInTime, currentTime, pricePerHour);
            vehicle.TimeParked = TimeParkedLongString(vehicle.CheckInTime, currentTime);

            return View(vehicle);
        }

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

            var editViewModel = new ViewModels.EditViewModel(parkedVehicle);
            editViewModel.VehicleTypes = db.VehicleType.ToList().Select(v => new SelectListItem
            {
                Selected = (v.Id == parkedVehicle.VehicleTypeId),
                Value = v.Id.ToString(),
                Text = v.Name
            });

            editViewModel.Members = db.Member.ToList().Select(v => new SelectListItem
            {
                Selected = (v.Id == parkedVehicle.MemberId),
                Value = v.Id.ToString(),
                Text = v.FullName
            });

            return View(editViewModel);
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
               new string[] { "Id", "VehicleTypeId", "MemberId", "RegNo", "Color", "Brand", "Model", "NumberOfWheels" }))
            {

                ParkedVehicle alreadyParkedVehicle = db.ParkedVehicle
                    .Where(v => v.Id != vehicleToUpdate.Id)
                    .FirstOrDefault(v => v.RegNo.ToLower() == vehicleToUpdate.RegNo.ToLower());
                if (alreadyParkedVehicle != null)
                {
                    ModelState.AddModelError(string.Empty, $"Fordon med registreringsnummer {alreadyParkedVehicle.RegNo} finns redan");
                }


                if (ModelState.IsValid)
                {

                    try
                    {
                        db.SaveChanges();
                        var detailViewModel = new ViewModels.DetailsViewModel(vehicleToUpdate);
                        return View("Details", detailViewModel);
                    }
                    catch (DataException /* dex */)
                    {
                        //Log the error (uncomment dex variable name and add a line here to write a log.
                        ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                    }
                }
            }

            var editViewModel = new ViewModels.EditViewModel(vehicleToUpdate);
            editViewModel.VehicleTypes = db.VehicleType.ToList().Select(v => new SelectListItem
            {
                Selected = (v.Id == vehicleToUpdate.VehicleTypeId),
                Value = v.Id.ToString(),
                Text = v.Name
            });

            editViewModel.Members = db.Member.ToList().Select(v => new SelectListItem
            {
                Selected = (v.Id == vehicleToUpdate.MemberId),
                Value = v.Id.ToString(),
                Text = v.FullName
            });
            return View(editViewModel);
        }

        #endregion

        #region Receipt

        public ActionResult Receipt(ViewModels.CheckOutViewModel checkedOutVehicle)
        {
            var receiptVehicle = new ViewModels.ReceiptViewModel(checkedOutVehicle);
            double pricePerHour = db.Garage.FirstOrDefault().PricePerHour;

            receiptVehicle.PricePerHour = string.Format("{0:F2} kr", pricePerHour);
            receiptVehicle.TotalPrice = TotalPriceString(receiptVehicle.CheckInTime, receiptVehicle.CheckOutTime, pricePerHour);
            receiptVehicle.TimeParked = TimeParkedLongString(receiptVehicle.CheckInTime, receiptVehicle.CheckOutTime);

            return View(receiptVehicle);
        }

        #endregion

        #region Functions

        public string TotalPriceString(DateTime checkInTime, DateTime checkOutTime, double pricePerHour)
        {
            return string.Format("{0:F0} kr", TotalPrice(checkInTime, checkOutTime, pricePerHour));
        }

        public double TotalPrice(DateTime checkInTime, DateTime checkOutTime, double pricePerHour)
        {
            var totalParkedTime = checkOutTime - checkInTime;
            double totalParkedHours = ((TimeSpan)totalParkedTime).TotalHours;

            int startedHours = (int)Math.Ceiling(totalParkedHours);

            return startedHours * pricePerHour;
        }

        public TimeSpan TimeParked(DateTime checkInTime, DateTime checkOutTime)
        {
            return checkOutTime - checkInTime;
        }

        public string TimeParkedLongString(DateTime checkInTime, DateTime checkOutTime)
        {
            var timeParked = TimeParked(checkInTime, checkOutTime);
            string timeParkedString = "";
            if (timeParked.Days == 1) timeParkedString += timeParked.ToString($"%d") + " dag ";
            if (timeParked.Days > 1) timeParkedString += timeParked.ToString($"%d") + " dagar ";
            if (timeParked.Hours == 1) timeParkedString += timeParked.ToString($"%h") + " timme ";
            if (timeParked.Hours > 1) timeParkedString += timeParked.ToString($"%h") + " timmar ";
            if (timeParked.Minutes == 1) timeParkedString += timeParked.ToString($"%m") + " minut ";
            if (timeParked.Minutes > 1) timeParkedString += timeParked.ToString($"%m") + " minuter ";
            if (timeParked.Seconds == 1) timeParkedString += timeParked.ToString($"%s") + " sekund ";
            if (timeParked.Seconds > 1) timeParkedString += timeParked.ToString($"%s") + " sekunder ";
            return timeParkedString;
        }

        public string TimeParkedShortString(DateTime checkInTime, DateTime checkOutTime)
        {
            var timeParked = TimeParked(checkInTime, checkOutTime);
            string timeParkedString = "";
            if ((timeParked.Days + timeParked.Hours) > 0) timeParkedString += timeParked.Days * 24 + timeParked.Hours + "t ";
            if (timeParked.Minutes > 0) timeParkedString += timeParked.ToString($"%m") + "m ";
            if (timeParked.Seconds > 0) timeParkedString += timeParked.ToString($"%s") + "s ";
            return timeParkedString;
        }
        #endregion

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
