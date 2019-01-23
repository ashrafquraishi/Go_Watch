using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GoWatch.Models
{
    public class Count
    {
        [Key]
      
        public int CountId { get; set; }

        public string Message { get; set; }
        public DateTime Countdate { get; set; }
        public int Countlike { get; set; }


    }
}