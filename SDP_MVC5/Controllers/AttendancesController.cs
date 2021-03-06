﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SDP_MVC5.Models;

namespace SDP_MVC5.Controllers
{
    [Authorize]
    public class AttendancesController : Controller
    {
        private StudentContext db = new StudentContext();
        //Todo: Attendance: add new fields
        // GET: Attendances
        public ActionResult Index()
        {
            return View(db.Attendence.Where(x=>x.studentID.ToString() == User.Identity.Name.Substring(0,8)).ToList());
        }

        // GET: Attendances/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attendance attendance = db.Attendence.Find(id);
            if (attendance == null)
            {
                return HttpNotFound();
            }
            return View(attendance);
        }

        //route Create/workshopID/bookingID/workshopName
        //[Route(new(workshopID=1, "bookingID", "workshopName",)]
        
        public ActionResult Create(int workshopID, int bookingID, string workshopName)
        {
            Attendance attendence0 = db.Attendence.Where(x => x.bookingID == bookingID
                && x.workshopID == workshopID).FirstOrDefault();
            if (attendence0 == null)
            {
                Attendance attendence = new Attendance();
                attendence.studentID = int.Parse(User.Identity.Name.Substring(0, 8));
                attendence.workshopName = workshopName;
                attendence.createdtime = DateTime.Today;
                attendence.attendancetime = DateTime.Now;
                attendence.bookingID = bookingID;
                attendence.workshopID = workshopID;
                return View(attendence);
            }
            else
            {
                return RedirectToAction("Edit", "Attendances", new { @id = attendence0.ID });
            }
        }

        [Route("Attendances/{workshopID:int}/{bookingID:int}/{workshopName}")]
        public ActionResult Create2(int workshopID, int bookingID, string workshopName)
        {
            Attendance attendence = new Attendance();
            attendence.studentID = int.Parse(User.Identity.Name.Substring(0, 8));
            attendence.workshopName = workshopName;
            attendence.createdtime = DateTime.Today;
            attendence.attendancetime = DateTime.Now;
            attendence.bookingID = bookingID;
            attendence.workshopID = workshopID;
            return View("Create",attendence);
        }

        // POST: Attendance/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,workshopID,studentID,bookingID,createdtime,attendancetime, workshopName, passCode")] Attendance attendance)
        {
            if (ModelState.IsValid)
            {
                db.Attendence.Add(attendance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(attendance);
        }

        // GET: Attendances/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attendance attendance = db.Attendence.Find(id);
            if (attendance == null)
            {
                return HttpNotFound();
            }
            return View(attendance);
        }

        // POST: Attendances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Attendance attendance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(attendance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(attendance);
        }

        // GET: Attendances/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attendance attendance = db.Attendence.Find(id);
            if (attendance == null)
            {
                return HttpNotFound();
            }
            return View(attendance);
        }

        // POST: Attendances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Attendance attendance = db.Attendence.Find(id);
            db.Attendence.Remove(attendance);
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
