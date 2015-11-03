using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SDP_MVC5.Models;

namespace SDP_MVC5.Controllers
{

    [Authorize]
    public class HomeController : Controller
    {
        SDP_MVC5.Models.StudentContext db = new StudentContext();
        //
        // GET: /Demo/
        public ActionResult Index()
        {
            //return View();
            return RedirectToAction("Newsession", "Home");
        }

        public ActionResult Student()
        {
            return View();
        }

        public ActionResult Help()
        {
            return View();
        }
        public ActionResult Newsession()
        {
            return View();
        }
        
        public ActionResult BookingCancel(int WorkshopID, int StudentID)
        {
            //int studentID = int.Parse(User.Identity.Name.ToString().Substring(0, 8));
            db.Reminder.RemoveRange(db.Reminder.Where(c => c.studentID == StudentID && c.workshopID == WorkshopID));
            db.SaveChanges();
            db.Waitings.RemoveRange(db.Waitings.Where(c => c.workshopID == WorkshopID && c.studentID == StudentID));
            db.SaveChanges();
            db.Attendence.RemoveRange(db.Attendence.Where(c => c.studentID == StudentID && c.workshopID == WorkshopID));
            db.SaveChanges();

            return RedirectToAction("Newsession");
        }

        public ActionResult BookingHistory()
        {
            return View();
        }
        public ActionResult Search()
        {
            return View();
        }
        public ActionResult SearchHistory()
        {
            return View();
        }
        public ActionResult SearchWorkshopList()
        {
            return View();
        }
        public ActionResult Program()
        {
            return View();
        }
        public ActionResult Workshop()
        {
            return View();
        }
        public ActionResult WorkshopList(int id)
        {
            //Todo: if id=null then error
            return View(id);
        }
        public ActionResult Signup()
        {
            return View();
        }

        public ActionResult Json_Student()
        {
            return View();
        }

        public ActionResult Json_WorkshopBookingSearch()
        {
            return View();
        }

        public ActionResult Json_WorkshopSearch()
        {
            return View();
        }

        public ActionResult Json_WorkshopWorkshopSets()
        {
            return View();
        }

        public ActionResult Json_Index()
        {
            return View();
        }
    }
}