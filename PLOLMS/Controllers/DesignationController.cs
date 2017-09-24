using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PLOLMS.Models;

namespace PLOLMS.Controllers
{
    public class DesignationController : Controller
    {
        private PLOLAMSEntities db = new PLOLAMSEntities();
        // GET: Designation
        public ActionResult Index()
        {
            List<Designation> objDesignationList = new List<Designation>();
            objDesignationList = db.Designations.ToList();
            ViewBag.Designation = objDesignationList;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Designation designation)
        {
            if (ModelState.IsValid)
            {
                db.Designations.Add(designation);
                db.SaveChanges();
                return RedirectToAction("Index", "Designation");
            }
            List<Designation> objDesignationList = new List<Designation>();
            objDesignationList = db.Designations.ToList();
            ViewBag.Designation = objDesignationList;
            return View(designation);
        }
    }
}