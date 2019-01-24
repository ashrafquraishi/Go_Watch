using GoWatch.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoWatch.Controllers
{
    public class GuestListController : Controller
    {
        public ApplicationDbContext db = new ApplicationDbContext();
        // GET: GuestList
        public ActionResult Index()
        {
            return View(db.GuestList.ToList());
        }


        public ActionResult CreateGuest()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateBarEvents([Bind(Include = "GuestListID,Going,Arrived")] GuestList guestList)
        {
            if (ModelState.IsValid)
            {

                var userId = User.Identity.GetUserId();
                guestList.ApplicationUserId = userId;

                db.GuestList.Add(guestList);
                db.SaveChanges();
                return RedirectToAction("GuestListDetails", new { id = guestList.EventID });

            }
            return View(guestList);
        }
        public ActionResult GuestListDetails()
        {

            var FoundUserId = User.Identity.GetUserId();
            GuestList guestList = db.GuestList.Where(c => c.ApplicationUserId == FoundUserId).FirstOrDefault();
            return View(guestList);
        }
    }
}