using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GarageV2.Models
{
    public class VehicleType
    {
        public int Id { get; set; }
        
        [Display(Name="Fordonstyp")]
        public String Name { get; set; }
    }
}