using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using AftermathArc.Models;
using System.Data;
using System.Net;

namespace AftermathArc.Controllers
{
    public class PodcastController : Controller
    {
        private podcastdbEntities db = new podcastdbEntities();
        // GET: Podcast
        public ActionResult Index()
        {

            return View(db.podcastinfoes.ToList());
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            podcastinfo info = db.podcastinfoes.Find(id);
            if (info == null)
            {
                return HttpNotFound();
            }
            return View(info);
        }
    }
}