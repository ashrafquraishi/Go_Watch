﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GoWatch.Models
{
    public class Article
    {
        [Key]
       
        public int AutoId { get; set; }

        public string Title { get; set; }


        public string Description { get; set; }

        public bool Active { get; set; }
    }
}