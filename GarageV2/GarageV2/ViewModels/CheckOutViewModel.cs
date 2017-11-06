using GarageV2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GarageV2.ViewModels
{
    public class CheckOutViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Fordonstyp")]
        public string VehicleType { get; set; }

        [Display(Name = "Medlem")]
        public string Member { get; set; }

        [Required]
        [Display(Name = "Registreringsnummer")]
        public string RegNo { get; set; }

        [Display(Name = "Färg")]
        public string Color { get; set; }

        [Display(Name = "Märke")]
        public string Brand { get; set; }

        [Display(Name = "Modell")]
        public string Model { get; set; }

        [Range(0, 12)]
        [Display(Name = "Antal hjul")]
        public int NumberOfWheels { get; set; }

        [Display(Name = "Incheckad")]
        public DateTime CheckInTime { get; set; }

        [Display(Name = "Utcheckad")]
        public DateTime? CheckOutTime { get; set; }

        [Display(Name = "Totalt pris")]
        public string TotalPriceString { get; set; }

        public CheckOutViewModel() { }

        public CheckOutViewModel(ParkedVehicle vehicle)
        {
            Id = vehicle.Id;
            RegNo = vehicle.RegNo;
            VehicleType = vehicle.VehicleType.Name;
            Member = vehicle.Member.FullName;
            Color = vehicle.Color;
            Brand = vehicle.Brand;
            Model = vehicle.Model;
            NumberOfWheels = vehicle.NumberOfWheels;
            CheckInTime = vehicle.CheckInTime;
            TotalPriceString = vehicle.TotalPriceString;
            CheckOutTime = vehicle.CheckOutTime;
        }
    }
}