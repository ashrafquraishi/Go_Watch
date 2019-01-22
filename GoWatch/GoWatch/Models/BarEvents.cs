using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GoWatch.Models
{
    public class BarEvents
    {
        [Key]
        public int EventID { get; set; }
        [Display(Name = "Bar Name")]
        public string BarName { get; set; }
        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        [Display(Name = "Zip Code")]

        public string ZipCode { get; set; }

        [Display(Name = "Team Name")]
        public string TeamName { get; set; }
        [DataType(DataType.DateTime)]
        DateTime? DateTime { get; set; }
    }
}