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
    public class OfficeInfoesController : Controller
    {
        private PLOLAMSEntities db = new PLOLAMSEntities();

        //Office List Type wise
        //Head office List View
        public ActionResult OfficeList(int TypeId)
        {
            List<view_OfficeInfoDetails> objOfficeInfoList = new List<view_OfficeInfoDetails>();
            objOfficeInfoList = db.view_OfficeInfoDetails.Where(Item => Item.OTId == TypeId).ToList();

            ViewBag.OfficeTypeId = TypeId;

            var OfficeTypeInfo = db.OfficeTypes.Where(Item => Item.OTId == TypeId).SingleOrDefault();
            ViewBag.OfficeTypeName = OfficeTypeInfo.OTName;
            return View(objOfficeInfoList);
        }



        //Head office List View
        public ActionResult HeadOfficeList()
        {
            List<view_OfficeInfoDetails> objHeadOfficeInfoList = new List<view_OfficeInfoDetails>();
            objHeadOfficeInfoList = db.view_OfficeInfoDetails.Where(Item => Item.OTId == 1).ToList();
            return View(objHeadOfficeInfoList);
        }


        //Create Head Office Information
        public ActionResult HeadOfficeCreate()
        {
            ViewBag.DistrictId = new SelectList(db.DistrictInfoes, "DisId", "DisName");
            ViewBag.OTId = new SelectList(db.OfficeTypes, "OTId", "OTName");
            ViewBag.ParentOfficeId = new SelectList(db.OfficeInfoes, "OfficeId", "OfficName");
            return View();
        }

        // POST: OfficeInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult HeadOfficeCreate(OfficeInfo officeInfo)
        {
            if (ModelState.IsValid)
            {
                db.OfficeInfoes.Add(officeInfo);
                db.SaveChanges();
                return RedirectToAction("HeadOfficeCreateList");
            }

            ViewBag.DistrictId = new SelectList(db.DistrictInfoes, "DisId", "DisName", officeInfo.DistrictId);
            ViewBag.OTId = new SelectList(db.OfficeTypes, "OTId", "OTName", officeInfo.OTId);
            ViewBag.ParentOfficeId = new SelectList(db.OfficeInfoes, "OfficeId", "OfficName");
            return View(officeInfo);
        }


        // GET: OfficeInfoes
        public ActionResult Index()
        {
            var officeInfoes = db.OfficeInfoes.Include(o => o.DistrictInfo).Include(o => o.OfficeType);
            return View(officeInfoes.ToList());
        }

        public ActionResult OfdiceDetailsById(int? OfficeId)
        {
            if (OfficeId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            view_OfficeInfoDetails objview_OfficeInfoDetails = db.view_OfficeInfoDetails.Where(item => item.OfficeId == OfficeId).SingleOrDefault();
            if (objview_OfficeInfoDetails == null)
            {
                return HttpNotFound();
            }
            return View(objview_OfficeInfoDetails);
        }


        // GET: OfficeInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfficeInfo officeInfo = db.OfficeInfoes.Find(id);
            if (officeInfo == null)
            {
                return HttpNotFound();
            }
            return View(officeInfo);
        }
        //Get: OfficeInfoes/CreateOfficeByType
        public ActionResult CreateOfficeByType(int OTId)
        {
            ViewBag.OfficeTypeId = OTId;
            ViewBag.DistrictId = new SelectList(db.DistrictInfoes, "DisId", "DisName");
            ViewBag.OTId = new SelectList(db.OfficeTypes, "OTId", "OTName", OTId);
            ViewBag.OfficeTypeName = (db.OfficeTypes.Where(Item => Item.OTId == OTId).SingleOrDefault()).OTName;
            List<OfficeInfo> objParentOfficeList = new List<OfficeInfo>();
            objParentOfficeList = db.OfficeInfoes.Where(Item => Item.OTId == (OTId-1)).ToList();
            ViewBag.ParentOfficeId = new SelectList(objParentOfficeList, "OfficeId", "OfficName");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOfficeByType(OfficeInfo officeInfo)
        {
            if (ModelState.IsValid)
            {
                officeInfo.OfficeIsActive = true;
                db.OfficeInfoes.Add(officeInfo);
                db.SaveChanges();
                return RedirectToAction("OfficeList",new { TypeId = officeInfo.OTId}); 

            }

            ViewBag.DistrictId = new SelectList(db.DistrictInfoes, "DisId", "DisName", officeInfo.DistrictId);
            ViewBag.OTId = new SelectList(db.OfficeTypes, "OTId", "OTName", officeInfo.OTId);
            List<OfficeInfo> objParentOfficeList = new List<OfficeInfo>();
            objParentOfficeList = db.OfficeInfoes.Where(Item => Item.OTId == (officeInfo.OTId - 1)).ToList();
            ViewBag.ParentOfficeId = new SelectList(objParentOfficeList, "OfficeId", "OfficName",officeInfo.ParentOfficeId);
            return View(officeInfo);
        }



        // GET: OfficeInfoes/Create
        public ActionResult Create()
        {
            ViewBag.DistrictId = new SelectList(db.DistrictInfoes, "DisId", "DisName");
            ViewBag.OTId = new SelectList(db.OfficeTypes, "OTId", "OTName");
            return View();
        }

        // POST: OfficeInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OfficeId,OfficeCode,OfficName,OfficeSN,OAdd1,OAdd2,OAdd3,DistrictId,OTId,OPhoneNo,OMobileNo,OFaxNo,Odesc,OfficeIsActive,ParentOfficeId")] OfficeInfo officeInfo)
        {
            if (ModelState.IsValid)
            {
                db.OfficeInfoes.Add(officeInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DistrictId = new SelectList(db.DistrictInfoes, "DisId", "DisName", officeInfo.DistrictId);
            ViewBag.OTId = new SelectList(db.OfficeTypes, "OTId", "OTName", officeInfo.OTId);
            return View(officeInfo);
        }

        // GET: OfficeInfoes/Edit/5
        public ActionResult Edit(int? OfficeId)
        {
            if (OfficeId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfficeInfo officeInfo = db.OfficeInfoes.Find(OfficeId);
            if (officeInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.DistrictId = new SelectList(db.DistrictInfoes, "DisId", "DisName", officeInfo.DistrictId);
            ViewBag.OTId = new SelectList(db.OfficeTypes, "OTId", "OTName", officeInfo.OTId);
            List<OfficeInfo> objParentOfficeList = new List<OfficeInfo>();
            objParentOfficeList = db.OfficeInfoes.Where(Item => Item.OTId == (officeInfo.OTId - 1)).ToList();
            ViewBag.ParentOfficeId = new SelectList(objParentOfficeList, "OfficeId", "OfficName", officeInfo.ParentOfficeId);
            return View(officeInfo);
        }

        // POST: OfficeInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OfficeId,OfficeCode,OfficName,OfficeSN,OAdd1,OAdd2,OAdd3,DistrictId,OTId,OPhoneNo,OMobileNo,OFaxNo,Odesc,OfficeIsActive,ParentOfficeId")] OfficeInfo officeInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(officeInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("OfficeList", new { TypeId = officeInfo.OTId });
            }
            ViewBag.DistrictId = new SelectList(db.DistrictInfoes, "DisId", "DisName", officeInfo.DistrictId);
            ViewBag.OTId = new SelectList(db.OfficeTypes, "OTId", "OTName", officeInfo.OTId);
            ViewBag.ParentOfficeId = new SelectList(db.OfficeInfoes, "OfficeId", "OfficName",officeInfo.ParentOfficeId);
            return View(officeInfo);
        }

        // GET: OfficeInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfficeInfo officeInfo = db.OfficeInfoes.Find(id);
            if (officeInfo == null)
            {
                return HttpNotFound();
            }
            return View(officeInfo);
        }

        // POST: OfficeInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OfficeInfo officeInfo = db.OfficeInfoes.Find(id);
            db.OfficeInfoes.Remove(officeInfo);
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
