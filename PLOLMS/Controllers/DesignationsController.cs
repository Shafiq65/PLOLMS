﻿using System;
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
    public class DesignationsController : Controller
    {
        private PLOLAMSEntities db = new PLOLAMSEntities();

        // GET: Designations
        public ActionResult Index()
        {
            return View(db.Designations.ToList());
        }


        public ActionResult CreateAndView()
        {
            List<Designation> objDesignationList = new List<Designation>();
            objDesignationList = db.Designations.ToList();
            ViewBag.Designations = objDesignationList;
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAndView(Designation Designations)

        {
            if (ModelState.IsValid)
            {
                db.Designations.Add(Designations);
                db.SaveChanges();
                return RedirectToAction("CreateAndView", "Designations");
            }
            List<Designation> objDesignationList = new List<Designation>();
            objDesignationList = db.Designations.ToList();
            ViewBag.Designations = objDesignationList;
            return View(Designations);

        }



        // GET: Designations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Designation designation = db.Designations.Find(id);
            if (designation == null)
            {
                return HttpNotFound();
            }
            return View(designation);
        }

        // GET: Designations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Designations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DId,Dname,DesignationCode,DDesc,IsActive")] Designation designation)
        {
            if (ModelState.IsValid)
            {
                db.Designations.Add(designation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(designation);
        }

        // GET: Designations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Designation designation = db.Designations.Find(id);
            if (designation == null)
            {
                return HttpNotFound();
            }
            return View(designation);
        }

        // POST: Designations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DId,Dname,DesignationCode,DDesc,IsActive")] Designation designation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(designation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("CreateAndView");
            }
            return View(designation);
        }

        // GET: Designations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Designation designation = db.Designations.Find(id);
            if (designation == null)
            {
                return HttpNotFound();
            }
            return View(designation);
        }

        // POST: Designations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Designation designation = db.Designations.Find(id);
            db.Designations.Remove(designation);
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
