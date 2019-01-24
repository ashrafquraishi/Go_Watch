using GoWatch.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoWatch.Controllers
{
    public class BarEventController : Controller
    {
        public ApplicationDbContext db = new ApplicationDbContext();
        // GET: BarEvent
        public ActionResult BarIndex(string searchString)
        {
            var Word = db.BarEvent.ToList();


            if (!String.IsNullOrEmpty(searchString))
            {
                Word = Word.Where(s => s.TeamName.Contains(searchString)).ToList();
            }

            return View(Word);
        }
        public ActionResult CreateBarEvents()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateBarEvents([Bind(Include = "EventID,BarName,Address,City,State,ZipCode,City,State,TeamName,EventTime,Time")] BarEvents barEvents)
        {
            if (ModelState.IsValid)
            {

                var userId = User.Identity.GetUserId();
                barEvents.ApplicationUserId = userId;

                db.BarEvent.Add(barEvents);
                db.SaveChanges();
                return RedirectToAction("BarEventDetails", new { id = barEvents.EventID });

            }
            return View(barEvents);
        }
        public ActionResult BarEventDetails()
        {

            var FoundUserId = User.Identity.GetUserId();
            BarEvents barEvents = db.BarEvent.Where(c => c.ApplicationUserId == FoundUserId).FirstOrDefault();
            return View(barEvents);
        }
        public ActionResult BarEventsOnMap()
        {
           
            return View();
        }
        //[HttpPost]
        //public ActionResult BarEventsOnMap(string id)
        //{
        //    BarEvents barEvents = null;
        //    if (id == null)
        //    {
        //        var UserId = User.Identity.GetUserId();

        //        barEvents = db.BarEvent.Where(c => c.ApplicationUserId == UserId).FirstOrDefault();
        //        var firstname = (from c in db.BarEvent where c.ApplicationUserId == UserId select c.BarName).FirstOrDefault();

        //        var address = (from c in db.BarEvent where c.ApplicationUserId == UserId select c.Address).FirstOrDefault();
        //        var zipcode = (from c in db.BarEvent where c.ApplicationUserId == UserId select c.ZipCode).FirstOrDefault();

        //        //Store into View Bag to be retrieved in View page
        //        ViewBag.Address = address;
        //        ViewBag.Zip = zipcode;


        //    }
        //    return View(barEvents);
        //}
    }
}