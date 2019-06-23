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
    public class ImpExpController : Controller
    {
        private PmsManagerDb db = new PmsManagerDb();

        //
        // GET: /ImpExp/

        public ActionResult Index([Bind(Prefix="id")] int pmsId)
        {
            var pms = db.PmsSet.Find(pmsId);
            if (pms != null)
            {
                return View(pms.formats);
            }
            return HttpNotFound();
        }

        //
        // GET: /ImpExp/Create

        public ActionResult Create([Bind(Prefix = "id")] int pmsId)
        {
            ViewBag.pmsId = pmsId;
            return View();
        }

        //
        // POST: /ImpExp/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ImpExpAssociated impexpassociated)
        {
            if (ModelState.IsValid)
            {
                db.formats.Add(impexpassociated);
                db.SaveChanges();
                return RedirectToAction("Index", new { id = impexpassociated.PmsId });
            }

            return View(impexpassociated);
        }

        //
        // GET: /ImpExp/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ImpExpAssociated impexpassociated = db.formats.Find(id);
            if (impexpassociated == null)
            {
                return HttpNotFound();
            }
            return View(impexpassociated);
        }

        //
        // POST: /ImpExp/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ImpExpAssociated impexpassociated)
        {
            if (ModelState.IsValid)
            {
                db.Entry(impexpassociated).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { id = impexpassociated.PmsId });
            }
            return View(impexpassociated);
        }

        //
        // GET: /ImpExp/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ImpExpAssociated impexpassociated = db.formats.Find(id);
            if (impexpassociated == null)
            {
                return HttpNotFound();
            }
            return View(impexpassociated);
        }

        //
        // POST: /ImpExp/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ImpExpAssociated impexpassociated = db.formats.Find(id);
            db.formats.Remove(impexpassociated);
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