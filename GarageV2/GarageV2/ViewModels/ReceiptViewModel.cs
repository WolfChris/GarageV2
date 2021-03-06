﻿using System;
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

        [Display(Name = "Ägare")]
        public string Owner { get; set; }

        [Display(Name = "Incheckad")]
        public DateTime CheckInTime { get; set; }

        [Display(Name = "Utcheckad")]
        public DateTime CheckOutTime { get; set; }

        [Display(Name = "Parkerad tid")]
        public string TimeParked { get; set; }

        [Display(Name = "Totalt pris")]
        public string TotalPrice { get; set; }

        [Display(Name = "Pris per timme")]
        public string PricePerHour { get; set; }

        public ReceiptViewModel(ViewModels.CheckOutViewModel vehicle)
        {
            RegNo = vehicle.RegNo;
            Owner = vehicle.Member;
            CheckInTime = vehicle.CheckInTime;
            CheckOutTime = (DateTime)vehicle.CheckOutTime;
        }

    }
}