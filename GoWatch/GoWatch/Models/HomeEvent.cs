using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GoWatch.Models
{
    public class HomeEvent
    {
        [Key]
        public int EventID { get; set; }
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        [Display(Name = "Zip Code")]
       
        public string ZipCode { get; set; }
    
        [Display(Name = "Team Name")]
        public string TeamName { get; set; }
        public string Rules { get; set; }
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? EventTime { get; set; }
        public string Time { get; set; }
        [DataType(DataType.Currency)]
        public double Price { get; set; }

  
        public List<HomeEvent> AllHomeEventAttendeeList { get; set; }
        //[Display(Name = "Rate Event")]
        //public double? Rating { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}