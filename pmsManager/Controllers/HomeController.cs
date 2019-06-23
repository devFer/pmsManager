using pmsManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;


namespace pmsManager.Controllers
{
    public class HomeController : Controller
    {
        private IPmsManagerDb _db;

        public HomeController()
        {
            _db = new PmsManagerDb();
        }

        public HomeController(IPmsManagerDb db)
        {
            _db = db;
        }

        public ActionResult Index(string searchTerm = null, int page = 1)
        {
            var model =
                _db.Query<Pms>()
                   .OrderByDescending(p => p.numberOfManagers)
                   .Where(p => searchTerm == null || p.pmsName.StartsWith(searchTerm))
                   .Select(p => new PmsListViewModel
                   {
                       Id = p.pmsId,
                       Name = p.pmsName,
                       CountOfFormats = p.formats.Count()
                   }).ToPagedList(page, 10);

            if (Request.IsAjaxRequest())
            {
                return PartialView("_Pms", model);
            }

            return View(model);
        }
        
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (_db != null)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
