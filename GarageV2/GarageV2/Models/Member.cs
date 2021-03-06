﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GarageV2.Models
{
    public class Member
    {
        [Display(Name = "Medlemsnummer")]
        public int Id { get; set; }
        
        [Display(Name = "Förnamn")]
        public string FirstName { get; set; }

        [Display(Name = "Efternamn")]
        public string LastName { get; set; }

        [Display(Name = "Medlem")]
        public string FullName {
            get {
                return FirstName + " " + LastName;
            }
        }

        [Display(Name = "Fordon")]
        public virtual ICollection<ParkedVehicle> ParkedVehicles { get; set; }
        

    }
}
