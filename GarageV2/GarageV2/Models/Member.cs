using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GarageV2.Models
{
    public class Member
    {
        public int Id { get; set; }

        [Display(Name = "Medlemsnummer")]
        public int MemberNo { get; set; }
        
        [Display(Name = "Förnamn")]
        public string FirstName { get; set; }

        [Display(Name = "Efternamn")]
        public string LastName { get; set; }

        [Display(Name = "Namn")]
        public string FullName {
            get {
                return FirstName + " " + LastName;
            }
        }
        

    }
}
