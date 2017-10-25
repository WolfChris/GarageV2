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

        [Display(Name ="Typ")]
        public string Type { get; set; }

        [Display(Name = "Reg nr")]
        public string RegNo { get; set; }

        [Display(Name = "Färg")]
        public string Color { get; set; }

        [Display(Name = "Parkerad tid")]
        public string TimeParked { get; set; }

    }
}