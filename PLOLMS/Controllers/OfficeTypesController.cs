using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PLOLMS.Models;

namespace PLOLMS.Controllers
{
    public class OfficeTypesController : Controller
    {
        private PLOLAMSEntities db = new PLOLAMSEntities();

        // GET: OfficeTypes
        public ActionResult Index()
        {
            List<OfficeType> objOfficeTypeList = new List<OfficeType>();
            objOfficeTypeList = db.OfficeTypes.ToList();
            return View(objOfficeTypeList);
        }

        public ActionResult CreateandView()
        {
            List<OfficeType> objOfficeTypeList = new List<OfficeType>();
            objOfficeTypeList = db.OfficeTypes.ToList();
            ViewBag.OfficeTypes = objOfficeTypeList;
            return View();


        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult CreateandView(OfficeType OfficeTypes)
        {
            if (ModelState.IsValid)
            {
                db.OfficeTypes.Add(OfficeTypes);
                db.SaveChanges();
                return RedirectToAction("CreateAndView", "OfficeTypes");
            }
            List<OfficeType> objOfficeTypeList = new List<OfficeType>();
            objOfficeTypeList = db.OfficeTypes.ToList();
            ViewBag.Designation = objOfficeTypeList;
            return View(OfficeTypes);


        }


        // GET: OfficeTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfficeType officeType = db.OfficeTypes.Find(id);
            if (officeType == null)
            {
                return HttpNotFound();
            }
            return View(officeType);
        }

        // GET: OfficeTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OfficeTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OTId,OTName,OTCode,OTDesc")] OfficeType officeType)
        {
            if (ModelState.IsValid)
            {
                db.OfficeTypes.Add(officeType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(officeType);
        }

        // GET: OfficeTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfficeType officeType = db.OfficeTypes.Find(id);
            if (officeType == null)
            {
                return HttpNotFound();
            }
            return View(officeType);
        }

        // POST: OfficeTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OTId,OTName,OTCode,OTDesc")] OfficeType officeType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(officeType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("CreateandView");
            }
            return View(officeType);
        }

        // GET: OfficeTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfficeType officeType = db.OfficeTypes.Find(id);
            if (officeType == null)
            {
                return HttpNotFound();
            }
            return View(officeType);
        }

        // POST: OfficeTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OfficeType officeType = db.OfficeTypes.Find(id);
            db.OfficeTypes.Remove(officeType);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
