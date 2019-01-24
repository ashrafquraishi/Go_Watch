using GoWatch.Models;
using Microsoft.AspNet.Identity;
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
        // GET: Fans/Create
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FanID,FavoriteTeam,FullName,Address,ZipCode,City,State")] Fan fan)
        {
            if (ModelState.IsValid)
            {
                
                    var userId = User.Identity.GetUserId();
                    fan.ApplicationUserId = userId;

                    db.Fan.Add(fan);
                    db.SaveChanges();
                    return RedirectToAction("FanDetails", new { id = fan.FanID });
             
            }
            return View(fan);

        }
        public ActionResult FanDetails()
        {

            var FoundUserId = User.Identity.GetUserId();
            Fan fan = db.Fan.Where(c => c.ApplicationUserId == FoundUserId).FirstOrDefault();
            return View(fan);
        }


        public ActionResult GetDirections()
        {

            return View();
        }

















    }
    
}