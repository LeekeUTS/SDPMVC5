using System;
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
    public class WaitingsController : Controller
    {
        private StudentContext db = new StudentContext();

        // GET: Waitings
        public ActionResult Index()
        {
            return View(db.Waitings.ToList());
        }

        // GET: Waitings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Waiting waiting = db.Waitings.Find(id);
            if (waiting == null)
            {
                return HttpNotFound();
            }
            return View(waiting);
        }

        // GET: Waitings/Create
        public ActionResult Create(int WorkshopID, string WorkshopName, int WorkshopSetID)
        {
            Waiting data = new Waiting();
            data.createdtime = DateTime.Today;
            data.workshopID = WorkshopID;
            data.workshopName = WorkshopName;
            data.workshopSetID = WorkshopSetID;
            data.studentID = int.Parse(User.Identity.Name.Substring(0, 8));
            return View(data);
        }

        // POST: Waitings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        // Todo: ask default value of database;
        public ActionResult Create([Bind(Include = "ID,workshopID,studentID,createdtime,workshopName,workshopSetID")] Waiting waiting)
        {
            if (ModelState.IsValid)
            {
                db.Waitings.Add(waiting);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(waiting);
        }

        // GET: Waitings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Waiting waiting = db.Waitings.Find(id);
            if (waiting == null)
            {
                return HttpNotFound();
            }
            return View(waiting);
        }

        // POST: Waitings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,workshopID,studentID,created")] Waiting waiting)
        {
            if (ModelState.IsValid)
            {
                db.Entry(waiting).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(waiting);
        }

        // GET: Waitings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Waiting waiting = db.Waitings.Find(id);
            if (waiting == null)
            {
                return HttpNotFound();
            }
            return View(waiting);
        }

        // POST: Waitings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Waiting waiting = db.Waitings.Find(id);
            db.Waitings.Remove(waiting);
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
