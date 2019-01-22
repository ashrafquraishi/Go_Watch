using GoWatch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoWatch.Controllers
{
    public class FanController : Controller
    {
        public ApplicationDbContext db = new ApplicationDbContext();
        // GET: Fan
        public ActionResult Index(string searchString)
        {
            var Word = db.Fan.ToList();


            if (!String.IsNullOrEmpty(searchString))
            {
                Word = Word.Where(s => s.FavoriteTeam.Contains(searchString)).ToList(); 
            }

            return View(Word);
        }
    }
}