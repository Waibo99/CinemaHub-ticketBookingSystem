using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CinemaHubFinalProject.Models;

namespace CinemaHubFinalProject.Controllers
{
    public class ShowsController : Controller
    {
        private Entities db = new Entities();

        // GET: Shows
        public ActionResult Index()
        {
            var shows = db.Shows.Include(s => s.Movies);
            return View(shows.ToList());
        }

        // GET: Shows/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shows shows = db.Shows.Find(id);
            if (shows == null)
            {
                return HttpNotFound();
            }
            return View(shows);
        }

        // GET: Shows/Create
        public ActionResult Create()
        {
            ViewBag.MovieName = new SelectList(db.Movies, "MovieName", "MovieName");
            return View();
        }

        // POST: Shows/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性。有关
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShowID,MovieName,ShowTime,Seat0,Seat1,Seat2,Seat3,Seat4,Seat5,Seat6,Seat7,Seat8,Seat9,Seat10,Seat11,Seat12,Seat13,Seat14,Seat15,Seat16,Seat17,Seat18,Seat19,Seat20,Seat21,Seat22,Seat23,Seat24,Seat25")] Shows shows)
        {
            if (ModelState.IsValid)
            {
                db.Shows.Add(shows);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MovieName = new SelectList(db.Movies, "MovieName", "Genre", shows.MovieName);
            return View(shows);
        }

        // GET: Shows/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shows shows = db.Shows.Find(id);
            if (shows == null)
            {
                return HttpNotFound();
            }
            ViewBag.MovieName = new SelectList(db.Movies, "MovieName", "Genre", shows.MovieName);
            return View(shows);
        }

        // POST: Shows/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性。有关
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShowID,MovieName,ShowTime,Seat0,Seat1,Seat2,Seat3,Seat4,Seat5,Seat6,Seat7,Seat8,Seat9,Seat10,Seat11,Seat12,Seat13,Seat14,Seat15,Seat16,Seat17,Seat18,Seat19,Seat20,Seat21,Seat22,Seat23,Seat24,Seat25")] Shows shows)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shows).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MovieName = new SelectList(db.Movies, "MovieName", "Genre", shows.MovieName);
            return View(shows);
        }

        // GET: Shows/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shows shows = db.Shows.Find(id);
            if (shows == null)
            {
                return HttpNotFound();
            }
            return View(shows);
        }

        // POST: Shows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Shows shows = db.Shows.Find(id);
            db.Shows.Remove(shows);
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
