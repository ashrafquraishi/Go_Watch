using GoWatch.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoWatch.Controllers
{
    public class HomeEventController : Controller
    {
        public ApplicationDbContext db = new ApplicationDbContext();
        // GET: HomeEvent
        public ActionResult Index(string searchString)
        {
            var Word = db.HomeEvent.ToList();


            if (!String.IsNullOrEmpty(searchString))
            {
                Word = Word.Where(s => s.TeamName.Contains(searchString)).ToList();
            }

            return View(Word);
        }
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventID,FullName,Address,City,State,ZipCode,City,State,TeamName,Rules,EventTime,Time,Price,Going,Arrived")] HomeEvent homeEvent)
        {
            if (ModelState.IsValid)
            {

                var userId = User.Identity.GetUserId();
                homeEvent.ApplicationUserId = userId;

                db.HomeEvent.Add(homeEvent);
                db.SaveChanges();
                return RedirectToAction("EventDetails", new { id = homeEvent.EventID });

            }
            return View(homeEvent);

        }
        public ActionResult EventDetails()
        {

            var FoundUserId = User.Identity.GetUserId();
            HomeEvent homeEvent = db.HomeEvent.Where(c => c.ApplicationUserId == FoundUserId).FirstOrDefault();
            return View(homeEvent);
        }
        public ActionResult GetAttendesList()
        {
            var FoundUserId = User.Identity.GetUserId();
            HomeEvent homeEvent = db.HomeEvent.Where(c => c.ApplicationUserId == FoundUserId).FirstOrDefault();
            //var GoingToEvent = db.GuestList.Where(s => s.Going).ToString();
           // GuestList guestList = new GuestList();
            HomeEvent homeEvents = new HomeEvent();
            var GoingToEvent = homeEvents.Going;
            if(GoingToEvent == false)
            {
                return View();
            }
            else
            {
                   List<HomeEvent> AllHomeEventAttendeeList;

                AllHomeEventAttendeeList =/* Convert.ToUInt16(homeEvent.FullName);//*/db.HomeEvent.Where(c => c.ApplicationUserId == FoundUserId).ToList();
                 
                if (AllHomeEventAttendeeList.Any())
                {
                    return View();
                }
                else
                {
                    return View(AllHomeEventAttendeeList);
                }
            }
          
        }
        public ActionResult GetDirections()
        {

            return View();
        }
        public ActionResult StripeForHomeEvents()
        {
            var stripePublishKey = ConfigurationManager.AppSettings["stripePublishableKey"];
            ViewBag.StripePublishKey = stripePublishKey;
            return View();
        }
    }
}