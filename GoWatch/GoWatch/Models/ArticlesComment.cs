using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GoWatch.Models
{
    public class ArticlesComment
    {

        [Key]
      
        public int CommentId { get; set; }

        public string Comments { get; set; }

        public DateTime? ThisDateTime { get; set; }

        public int ArticleId { get; set; }

        public int? Rating { get; set; }
    }
}