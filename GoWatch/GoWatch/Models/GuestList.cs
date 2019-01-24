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
        public bool Going { get; set; }
        public bool Arrived { get; set; }
        [ForeignKey("Fan")]
        public int FanID { get; set; }
        public Fan Fan { get; set; }


        [ForeignKey("HomeEvent")]
        public int EventID { get; set; }
        public HomeEvent HomeEvent { get; set; }


        [ForeignKey("BarEvents")]
        public int BarEventID { get; set; }
        public BarEvents BarEvents { get; set; }
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}