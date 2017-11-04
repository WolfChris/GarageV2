using System.ComponentModel.DataAnnotations;

namespace GarageV2.ViewModels
{
    public class MemberOverviewViewModel
    {
        [Display(Name = "Medlemsnummer")]
        public int Id { get; set; }

        [Display(Name = "Förnamn")]
        public string FirstName { get; set; }

        [Display(Name = "Efternamn")]
        public string LastName { get; set; }
    }
}