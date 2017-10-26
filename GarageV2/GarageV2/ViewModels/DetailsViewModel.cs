using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarageV2.ViewModels
{
    public class DetailsViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Typ")]
        public string Type { get; set; }

        [Display(Name = "Reg nr")]
        public string RegNo { get; set; }

        [Display(Name = "Färg")]
        public string Color { get; set; }

        [Display(Name = "Märke")]
        public string Brand { get; set; }

        [Display(Name = "Modell")]
        public string Model { get; set; }

        [Display(Name = "Antal Hjul")]
        public int NumberOfWheels { get; set; }

        [Display(Name = "Incheckningstid")]
        public DateTime CheckInTime { get; set; }
        
        [Display(Name = "Parkerad tid")]
        public string TimeParked { get; set; }

        [Display(Name = "Estimerad kostnad")]
        public string TotalPrice { get; set; }

        public DetailsViewModel(Models.ParkedVehicle vehicle)
        {
            Id = vehicle.Id;
            RegNo = vehicle.RegNo;
            Type = vehicle.Type.ToString();
            Color = vehicle.Color;
            Brand = vehicle.Brand;
            Model = vehicle.Model;
            NumberOfWheels = vehicle.NumberOfWheels;
            CheckInTime = vehicle.CheckInTime;
        }
    }
}