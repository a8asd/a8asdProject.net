using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheProject;

namespace TheWebProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddDriver()
        {
            ViewBag.Message = "Add a new driver";

            return View();
        }

        public List<DriverLocation> ListDrivers()
        {
            ViewBag.Message = "List drivers";
            List<DriverLocation> driverList = new List<DriverLocation>();
            return driverList;
        }
    }
}