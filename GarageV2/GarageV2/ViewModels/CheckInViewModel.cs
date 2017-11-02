using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GarageV2.ViewModels
{
    public class CheckInViewModel: Models.ParkedVehicle
    {
        public IEnumerable<SelectListItem> VehicleTypes { get; set; }
      
    }
}