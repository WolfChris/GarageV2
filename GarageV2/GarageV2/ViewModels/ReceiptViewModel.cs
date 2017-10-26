using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GarageV2.ViewModels
{
    public class ReceiptViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Reg nr")]
        public string RegNo { get; set; }

        [Display(Name = "Incheckad")]
        public DateTime CheckInTime { get; set; }

        [Display(Name = "Utcheckad")]
        public DateTime CheckOutTime { get; set; }

        [Display(Name = "Parkerad tid")]
        public string TimeParked { get; set; }

        [Display(Name = "Pris")]
        public string TotalPrice { get; set; }

        public ReceiptViewModel(Models.ParkedVehicle vehicle, double pricePerHour)
        {
            RegNo = vehicle.RegNo;
            CheckInTime = vehicle.CheckInTime;
            CheckOutTime = (DateTime)vehicle.CheckOutTime;
            
            double totalPrice = Controllers.ParkedVehiclesController.TotalPrice(CheckInTime, CheckOutTime, pricePerHour);
            TotalPrice = string.Format("{0:F0} kr", totalPrice);
            
            TimeParked = Controllers.ParkedVehiclesController.TimeParked(CheckInTime, CheckOutTime);
        }

    }
}