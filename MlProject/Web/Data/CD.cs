using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Data
{
    public class CD
    {
        [Display(Name = "Name:")]
        public string Name { get; set; }
        [Display(Name = "Amount Of Shedding:")]
        public int AmountOfShedding { get; set; }
        [Display(Name = "Easy To Groom:")]
        public int EasyToGroom { get; set; }
        [Display(Name = "General Health:")]
        public int GeneralHealth { get; set; }
        [Display(Name = "Kid Friendly:")]
        public int KidFriendly { get; set; }
        [Display(Name = "Pet Friendly:")]
        public int PetFriendly { get; set; }
        [Display(Name = "Potential For Playfulness:")]
        public int PotentialForPlayfulness { get; set; }
    }
}
