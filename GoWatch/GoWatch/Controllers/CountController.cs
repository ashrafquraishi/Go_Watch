using GoWatch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace GoWatch.Controllers
{
    public class CountController : Controller
    {
        public ApplicationDbContext db = new ApplicationDbContext();
        // GET: Count
        public ActionResult Index()
        {
            return View(db.Count.ToList());
        }

        // GET: Count/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Count count = db.Count.Find(id);
            if (count == null)
            {
                return HttpNotFound();

            }
            return View(count);
            }
        

        // GET: Count/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Count/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "CountId,Message,Countdate,Countlike")] Count count)
        {
            if (ModelState.IsValid)
            {
                count.Countlike = 0;
                count.Countdate = DateTime.Now;
                db.Count.Add(count);
                db.SaveChanges();
                return RedirectToAction("index");
            }
            return View(count);
        }

        public ActionResult Like(int id)
        {
            Count update = db.Count.ToList().Find(u => u.CountId == id);
            update.Countlike += 1;
            db.SaveChanges();
            return RedirectToAction("index");
        }


        // GET: Count/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Count/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Count/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Count/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
