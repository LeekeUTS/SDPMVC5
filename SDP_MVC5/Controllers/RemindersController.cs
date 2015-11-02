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
    [Authorize]
    public class RemindersController : Controller
    {
        private StudentContext db = new StudentContext();

        // GET: Reminders
        public ActionResult Index()
        {
            return View(db.Reminder.Where(x => x.studentID.ToString() == User.Identity.Name.Substring(0, 8)).ToList());
        }

        public ActionResult ReminderList()
        {
            Session.Abandon();
            return View(db.Reminder.Where(x => x.remindertime <= DateTime.Today ).ToList());
        }

        // GET: Reminders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reminder reminder = db.Reminder.Find(id);
            if (reminder == null)
            {
                return HttpNotFound();
            }
            return View(reminder);
        }

        // GET: Reminders/Create
        public ActionResult Create(int workshopID, int bookingID, string workshopName, DateTime starting)
        {
            Reminder reminder = new Reminder();
            reminder.studentID = int.Parse(User.Identity.Name.Substring(0, 8));
            reminder.createdtime = DateTime.Today;
            reminder.remindertime = DateTime.Now;
            reminder.starting = starting;
            reminder.workshopName = workshopName;
            reminder.bookingID = bookingID;
            reminder.workshopID = workshopID;
            return View(reminder);
        }

        // POST: Reminders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,workshopID,studentID,createdtime,remindertime,workshopName,starting")] Reminder reminder)
        {
            if (ModelState.IsValid)
            {
                db.Reminder.Add(reminder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(reminder);
        }

        // GET: Reminders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reminder reminder = db.Reminder.Find(id);
            if (reminder == null)
            {
                return HttpNotFound();
            }
            return View(reminder);
        }

        // POST: Reminders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,workshopID,studentID,createdtime,remindertime,workshopName")] Reminder reminder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reminder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reminder);
        }

        // GET: Reminders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reminder reminder = db.Reminder.Find(id);
            if (reminder == null)
            {
                return HttpNotFound();
            }
            return View(reminder);
        }

        // POST: Reminders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reminder reminder = db.Reminder.Find(id);
            db.Reminder.Remove(reminder);
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
