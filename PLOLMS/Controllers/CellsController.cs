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
    public class CellsController : Controller
    {
        private PLOLAMSEntities db = new PLOLAMSEntities();
        //create and show list
        public ActionResult CreateAndView()
        {
            List<Cell> objCellList = new List<Cell>();
            objCellList = db.Cells.ToList();
            ViewBag.Cells = objCellList;
            return View();
        }


        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAndView(Cell Cells)

        {
            if (ModelState.IsValid)
            {
                db.Cells.Add(Cells);
                db.SaveChanges();
                return RedirectToAction("CreateAndView", "Cells");
            }
            List<Cell> objCellList = new List<Cell>();
            objCellList = db.Cells.ToList();
            ViewBag.Designation = objCellList;
            return View(Cells);

        }


        // GET: Cells
        public ActionResult Index()
        {
            return View(db.Cells.ToList());
        }

        // GET: Cells/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cell cell = db.Cells.Find(id);
            if (cell == null)
            {
                return HttpNotFound();
            }
            return View(cell);
        }

        // GET: Cells/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cells/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CellId,CellName,CellCode,CellDesc")] Cell cell)
        {
            if (ModelState.IsValid)
            {
                db.Cells.Add(cell);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cell);
        }

        // GET: Cells/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cell cell = db.Cells.Find(id);
            if (cell == null)
            {
                return HttpNotFound();
            }
            return View(cell);
        }

        // POST: Cells/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CellId,CellName,CellCode,CellDesc")] Cell cell)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cell).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("CreateAndView");
            }
            return View(cell);
        }

        // GET: Cells/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cell cell = db.Cells.Find(id);
            if (cell == null)
            {
                return HttpNotFound();
            }
            return View(cell);
        }

        // POST: Cells/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cell cell = db.Cells.Find(id);
            db.Cells.Remove(cell);
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
