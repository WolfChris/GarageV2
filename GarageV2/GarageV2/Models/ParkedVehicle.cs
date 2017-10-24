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

        public string Type { get; set; }
        [Required]
        public string RegNo { get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }
        public string Modell { get; set; }
        [Range(0, 12)]
        public int NumberOfWheels { get; set; }

    }

}