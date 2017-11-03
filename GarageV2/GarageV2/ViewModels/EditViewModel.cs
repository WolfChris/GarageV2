using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GarageV2.Models;

namespace GarageV2.ViewModels
{
    public class EditViewModel 
    {
        public int Id { get; set; }

        [Display(Name = "Fordonstyp Id")]
        public int VehicleTypeId { get; set; }

        [Display(Name = "Ägar Id")]
        public int MemberId { get; set; }

        [Display(Name = "Fordonstyp")]
        public string VehicleType { get; set; }

        [Display(Name = "Reg nr")]
        public string RegNo { get; set; }

        [Display(Name = "Ägare")]
        public string MemberName { get; set; }

        [Display(Name = "Färg")]
        public string Color { get; set; }

        [Display(Name = "Märke")]
        public string Brand { get; set; }

        [Display(Name = "Modell")]
        public string Model { get; set; }

        [Display(Name = "Antal Hjul")]
        public int NumberOfWheels { get; set; }
        
        public EditViewModel(Models.ParkedVehicle vehicle)
        {
            Id = vehicle.Id;
            RegNo = vehicle.RegNo;
            VehicleType = vehicle.VehicleType.Name;
            MemberName = vehicle.Member.FullName;
            Color = vehicle.Color;
            Brand = vehicle.Brand;
            Model = vehicle.Model;
            NumberOfWheels = vehicle.NumberOfWheels;
        }

        public IEnumerable<SelectListItem> VehicleTypes { get; set; }

        public IEnumerable<SelectListItem> Members { get; set; }
        

    }
}