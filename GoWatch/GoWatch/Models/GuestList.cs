using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GoWatch.Models
{
    public class GuestList
    {
        [Key]
        public int GuestListID { get; set; }
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        public bool Going { get; set; }
        public bool Arrived { get; set; }
      
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}