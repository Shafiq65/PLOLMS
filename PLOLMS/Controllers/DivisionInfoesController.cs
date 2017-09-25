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
    public class DivisionInfoesController : Controller
    {
        private PLOLAMSEntities db = new PLOLAMSEntities();




        public ActionResult CreateAndView()
        {
            List<DivisionInfo> objDivisionInfoList = new List<DivisionInfo>();
            objDivisionInfoList = db.DivisionInfoes.ToList();
            ViewBag.DivisionInfoes = objDivisionInfoList;
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAndView(DivisionInfo DivisionInfoes)

        {
            if (ModelState.IsValid)
            {
                db.DivisionInfoes.Add(DivisionInfoes);
                db.SaveChanges();
                return RedirectToAction("CreateAndView", "DivisionInfoes");
            }
            List<DivisionInfo> objDivisionInfoList = new List<DivisionInfo>();
            objDivisionInfoList = db.DivisionInfoes.ToList();
            ViewBag.DivisionInfo = objDivisionInfoList;
            return View(DivisionInfoes);

        }
        // GET: DivisionInfoes
        public ActionResult Index()
        {
            return View(db.DivisionInfoes.ToList());
        }

        // GET: DivisionInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DivisionInfo divisionInfo = db.DivisionInfoes.Find(id);
            if (divisionInfo == null)
            {
                return HttpNotFound();
            }
            return View(divisionInfo);
        }

        // GET: DivisionInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DivisionInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DivisionId,DivisionName,DivisionCode,DivisionDesc")] DivisionInfo divisionInfo)
        {
            if (ModelState.IsValid)
            {
                db.DivisionInfoes.Add(divisionInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(divisionInfo);
        }

        // GET: DivisionInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DivisionInfo divisionInfo = db.DivisionInfoes.Find(id);
            if (divisionInfo == null)
            {
                return HttpNotFound();
            }
            return View(divisionInfo);
        }

        // POST: DivisionInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DivisionId,DivisionName,DivisionCode,DivisionDesc")] DivisionInfo divisionInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(divisionInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("CreateAndView");
            }
            return View(divisionInfo);
        }

        // GET: DivisionInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DivisionInfo divisionInfo = db.DivisionInfoes.Find(id);
            if (divisionInfo == null)
            {
                return HttpNotFound();
            }
            return View(divisionInfo);
        }

        // POST: DivisionInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DivisionInfo divisionInfo = db.DivisionInfoes.Find(id);
            db.DivisionInfoes.Remove(divisionInfo);
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
