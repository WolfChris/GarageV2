using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GarageV2.ViewModels
{
    public class DetailedOverviewViewModel
    {
        public int Id { get; set; }

        public int OwnerId { get; set; }

        [Display(Name = "Ägare")]
        public string Owner { get; set; }

        [Display(Name = "Fordonstyp")]
        public string VehicleType { get; set; }

        [Display(Name = "Reg nr")]
        public string RegNo { get; set; }

        [Display(Name = "Parkerad tid")]
        public string TimeParked { get; set; }

        [Display(Name = "Färg")]
        public string Color { get; set; }

        [Display(Name = "Märke")]
        public string Brand { get; set; }

        [Display(Name = "Modell")]
        public string Model { get; set; }

        [Display(Name = "Antal hjul")]
        public int NumberOfWheels { get; set; }

        [Display(Name = "Incheckad")]
        public DateTime CheckInTime { get; set; }

        [Display(Name = "Utcheckad")]
        public Nullable<DateTime> CheckOutTime { get; set; }

        [Display(Name = "Totalt pris")]
        public string TotalPrice { get; set; }

        public DetailedOverviewViewModel() { }

        public DetailedOverviewViewModel(Models.ParkedVehicle vehicle, double pricePerHour)
        {
            var parkedVehiclesController = new Controllers.ParkedVehiclesController();
            Id = vehicle.Id;
            RegNo = vehicle.RegNo;
            VehicleType = vehicle.VehicleType.Name;
            OwnerId = vehicle.MemberId;
            Owner = vehicle.Member.FullName;
            TimeParked = parkedVehiclesController.TimeParkedShortString(vehicle.CheckInTime, DateTime.Now);
            CheckInTime = vehicle.CheckInTime;
            CheckOutTime = vehicle.CheckOutTime;
            Color = vehicle.Color;
            Brand = vehicle.Brand;
            Model = vehicle.Model;
            NumberOfWheels = vehicle.NumberOfWheels;
            TotalPrice = parkedVehiclesController.TotalPriceString(vehicle.CheckInTime, DateTime.Now, pricePerHour);

        }
    }
}