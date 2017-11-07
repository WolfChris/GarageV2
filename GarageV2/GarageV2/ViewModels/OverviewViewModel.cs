using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GarageV2.ViewModels
{
    public class OverviewViewModel
    {
        public int Id { get; set; }
        
        public int OwnerId { get; set; }

        [Display(Name = "Ägare")]
        public string Owner { get; set; }

        [Display(Name ="Fordonstyp")]
        public string VehicleType { get; set; }

        [Display(Name = "Reg nr")]
        public string RegNo { get; set; }

        [Display(Name = "Parkerad tid")]
        public string TimeParked { get; set; }

    }
}