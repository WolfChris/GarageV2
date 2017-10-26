using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GarageV2.Models
{
    public class StatisticsModel
    {

        //Hur många fordon finns av varje typ?
        [Display(Name = "Typer och Förekomster")]
        public List<Controllers.TypeCount> TypeCounts { get; set; }
        //public int Cars { get; set; }
        //Hur många hjul finns det totalt i garaget just nu?
        [Display(Name = "Antal Hjul")]
        public int NumberWheels { get; set; }
        //Hur mycket har fordonen som står i garaget just nu parkerat för? (Totala minuter sedan de parkerade* minutpris)
        //Annan intressant statistik ni kan komma på.

    }
}