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
        public double TotalPrice { get; set; }

        [Display(Name = "Totalt pris")]
        public string TotalPriceString
        {
            get { return string.Format("{0:F0} kr", TotalPrice); }
        }      
    }
}