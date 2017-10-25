using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GarageV2.Models
{
    public class ParkedVehicle
    {
        public int Id { get; set; }
        [Display(Name = "Typ")]
        public Nullable<VehicleTypeEnum> Type { get; set; }
        [Required]
        [Display(Name = "Reg Nr")]
        public string RegNo { get; set; }
        [Display(Name = "Färg")]
        public string Color { get; set; }
        [Display(Name = "Märke")]
        public string Brand { get; set; }
        [Display(Name = "Modell")]
        public string Model { get; set; }
        [Range(0, 12)]
        [Display(Name = "Antal Hjul")]
        public int NumberOfWheels { get; set; }
        [Display(Name ="Incheckningstid")]
        public DateTime CheckInTime { get; set; }
        [Display(Name = "Utcheckningstid")]
        public Nullable<DateTime> CheckOutTime { get; set; }
        [Display(Name ="Totalla Priset")]
        public double TotalPrice { get; set; }

        public ParkedVehicle()
        {
            CheckInTime = DateTime.Now;
            CheckOutTime = null;
        }

    }

}