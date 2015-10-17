using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SDP_MVC5.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
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
            //todo: if id=nll then error
            return View(id);
        }
        public ActionResult Signup()
        {
            return View();
        }

        public ActionResult Json_SessionBookingSearch()
        {
            return View();
        }

        public ActionResult Json_SessionType()
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