using GarageV2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GarageV2.ViewModels
{
    public class CheckInViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Fordonstyp Id")]
        public int VehicleTypeId { get; set; }

        [Display(Name = "Medlems Id")]
        public int MemberId { get; set; }

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

        public virtual VehicleType VehicleType { get; set; }

        public virtual Member Member { get; set; }

        public IEnumerable<SelectListItem> VehicleTypes { get; set; }
        public IEnumerable<SelectListItem> Members { get; set; }

    }
}