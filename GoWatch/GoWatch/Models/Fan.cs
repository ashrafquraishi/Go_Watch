using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GoWatch.Models
{
    public class Fan
    {
        [Key]
        public int FanID { get; set; }

        [Display(Name = "Favorite Team")]
        public string FavoriteTeam { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get; set; }
    

        public string Address { get; set; }

       

        public string City { get; set; }

        public string State { get; set; }
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }


        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }


    }
}