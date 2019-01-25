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


        public ActionResult CreateGuestList()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateGuestList([Bind(Include = "GuestListID,FullName,Going")] GuestList guestList)
        {
            if (ModelState.IsValid)
            {

                var userId = User.Identity.GetUserId();
                guestList.ApplicationUserId = userId;

                db.GuestList.Add(guestList);
                db.SaveChanges();
                return RedirectToAction("GuestListDetails", new { id = guestList.GuestListID });

            }
            return View(guestList);
        }
        public ActionResult GuestListDetails()
        {

            var FoundUserId = User.Identity.GetUserId();
            GuestList guestList = db.GuestList.Where(c => c.ApplicationUserId == FoundUserId).FirstOrDefault();
            return View(guestList);
        }








/// <summary>
/// /////
/// 
/// 
/// 
/// 
/// </summary>
/// <returns></returns>
        public ActionResult ArrivedIndex()
        {
            return View(db.GuestList.ToList());
        }


        public ActionResult CreateGuestArrivedList()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateGuestArrivedList([Bind(Include = "GuestListID,FullName,Arrived")] GuestList guestList)
        {
            if (ModelState.IsValid)
            {

                var userId = User.Identity.GetUserId();
                guestList.ApplicationUserId = userId;

                db.GuestList.Add(guestList);
                db.SaveChanges();
                return RedirectToAction("GuestArrivedListDetails", new { id = guestList.GuestListID });

            }
            return View(guestList);
        }
        public ActionResult GuestArrivedListDetails()
        {

            var FoundUserId = User.Identity.GetUserId();
            GuestList guestList = db.GuestList.Where(c => c.ApplicationUserId == FoundUserId).FirstOrDefault();
            return View(guestList);
        }

    }
}