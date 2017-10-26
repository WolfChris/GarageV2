using System;
using System.ComponentModel.DataAnnotations;

namespace GarageV2.Models
{
    public class Garage
    {
        public int Id { get; set; }

        [Range(0,int.MaxValue)]
        [Display(Name = "Antal platser")]
        public int Capacity { get; set; }

        [Range(0, Double.MaxValue)]
        [Display(Name = "Pris per timme")]
        public double PricePerHour { get; set; }
    }
}