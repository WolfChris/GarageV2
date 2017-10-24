using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Mvc;
using System.Linq;
using System.Web;

namespace GarageV2.Models
{
    public class VehicleTypeModel
    {
        public VehicleTypeModel()
        {
            VehicleList = new List<SelectListItem>();
        }
        [DisplayName("Vehicle Types")]
        public List<SelectListItem> VehicleList
        {
            get;
            set;
        }
    }
}