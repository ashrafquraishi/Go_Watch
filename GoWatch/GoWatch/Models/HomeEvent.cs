using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GoWatch.Models
{
    public class HomeEvent
    {
        [Key]
        public int EventID { get; set; }
        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        [Display(Name = "Zip Code")]
       
        public string ZipCode { get; set; }
    
        [Display(Name = "Team Name")]
        public string TeamName { get; set; }
        public string Rules { get; set; }
        [DataType(DataType.DateTime)]
        DateTime? DateTime { get; set; }

        [DataType(DataType.Currency)]
        public double Price { get; set; }


        [Display(Name = "Rate Event")]
        public int RateEvent { get; set; }
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}