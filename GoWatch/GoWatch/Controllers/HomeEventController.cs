using GoWatch.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
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
        public ActionResult Create([Bind(Include = "EventID,FullName,Address,City,State,ZipCode,City,State,TeamName,Rules,DateTime,Price,RateEvent")] HomeEvent homeEvent)
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

    }
}