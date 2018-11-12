using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AftermathArc.Models;
using AftermathArc.ViewModels;

namespace AftermathArc.Controllers
{
    public class HomeController : Controller
    {
        private podcastdbEntities db = new podcastdbEntities();
        
        public ActionResult Index()
        {
            
            return View(db.podcastinfoes.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Where to find us";

            return View();
        }
  
    }
}