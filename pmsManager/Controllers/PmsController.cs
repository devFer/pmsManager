using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using pmsManager.Models;

namespace pmsManager.Controllers
{
    public class PmsController : Controller
    {
        private PmsManagerDb db = new PmsManagerDb();

        //
        // GET: /Pms/

        public ActionResult Index()
        {
            return View(db.PmsSet.ToList());
        }

        //
        // GET: /Pms/Details/5

        public ActionResult Details(int id = 0)
        {
            Pms pms = db.PmsSet.Find(id);
            if (pms == null)
            {
                return HttpNotFound();
            }
            return View(pms);
        }

        //
        // GET: /Pms/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Pms/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pms pms)
        {
            if (ModelState.IsValid)
            {
                db.PmsSet.Add(pms);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pms);
        }

        //
        // GET: /Pms/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Pms pms = db.PmsSet.Find(id);
            if (pms == null)
            {
                return HttpNotFound();
            }
            return View(pms);
        }

        //
        // POST: /Pms/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Pms pms)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pms).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pms);
        }

        //
        // GET: /Pms/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Pms pms = db.PmsSet.Find(id);
            if (pms == null)
            {
                return HttpNotFound();
            }
            return View(pms);
        }

        //
        // POST: /Pms/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pms pms = db.PmsSet.Find(id);
            db.PmsSet.Remove(pms);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}