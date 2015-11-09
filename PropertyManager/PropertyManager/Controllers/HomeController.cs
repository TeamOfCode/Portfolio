using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PropertyManager.Models;
using PropertyManager.Service;

namespace PropertyManager.Controllers
{
    public class HomeController : Controller
    {
        private PropertyManagerContext db = new PropertyManagerContext();
        private PropertyService _propertyService;
        public HomeController()
        {
            _propertyService=new PropertyService();
                
        }





        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}