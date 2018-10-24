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
            podcast_comments comment = db.podcast_comments.Find(id);
            if (info == null)
            {
                return HttpNotFound();
            }
            return View(info);
        }

        // GET: podcastinfo/Create
        public ActionResult Create()
        {
            //Check if admin
            if(User.Identity.Name != "")
            {
                return HttpNotFound();
            }
            return View();
        }

        // POST: podcastinfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,podcastName,Description,imagePath,audioPath,releaseDate")] podcastinfo podcastinfo)
        {
            if (ModelState.IsValid)
            {
                db.podcastinfoes.Add(podcastinfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(podcastinfo);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null || User.Identity.Name != "")
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            podcastinfo podcastinfo = db.podcastinfoes.Find(id);
            if (podcastinfo == null || User.Identity.Name != "")
            {
                return HttpNotFound();
            }
            return View(podcastinfo);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,podcastName,Description,imagePath,audioPath,releaseDate")] podcastinfo podcastinfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(podcastinfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(podcastinfo);
        }

        // GET: podcastinfo/Create
        public ActionResult AddPodcastComments()
        {
            //Check if admin
            if (User.Identity.IsAuthenticated == false)
            {
                return HttpNotFound();
            }
            return PartialView();
        }
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddPodcastComments(podcast_comments podcast_comments)
        {
            if (ModelState.IsValid)
            {
                if (podcast_comments.comment != null)
                {
                    podcast_comments.commentDate = DateTime.Now;
                    podcast_comments.username = User.Identity.Name;
                    db.podcast_comments.Add(podcast_comments);
                    db.SaveChanges();
                    return RedirectToAction("Details/" + podcast_comments.podcast_id);
                }
                else
                {
                    TempData["Message"] = "Please enter a comment";
                    return RedirectToAction("Details/" + podcast_comments.podcast_id);
                }
            }

            return PartialView(podcast_comments);
        }
        // GET: podcastinfo/Create
        public ActionResult DiplayComments(int? id)
        {
            //Check if admin
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            podcast_comments info = db.podcast_comments.Find(id);
            if (info == null)
            {
                return HttpNotFound();
            }
            return PartialView(info);
        }
 

    }
}