using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CinemaHubFinalProject.Models;
using Microsoft.AspNet.Identity;

namespace CinemaHubFinalProject.Controllers
{
    public class MoviesController : Controller
    {
        private Entities db = new Entities();

        // GET: Movies
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            AspNetUsers user = db.AspNetUsers.Find(userId);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }
            if (user.Level != true)
            {
                return new HttpStatusCodeResult(HttpStatusCode. BadRequest);
            }
            return View(db.Movies.ToList());
        }

        // GET: Movies/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movies movies = db.Movies.Find(id);
            if (movies == null)
            {
                return HttpNotFound();
            }
            return View(movies);
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性。有关
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MovieName,Genre,Description,Duration,Price,file")] CreateMovieViewModel model, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                Movies movie = new Movies();
                movie.MovieName = model.MovieName;
                movie.Genre = model.Genre;
                movie.Description = model.Description;
                movie.Duration = model.Duration;
                movie.Price = model.Price;
                movie.ImgPath = "../../images/"+Path.GetFileName(file.FileName);
                //System.Diagnostics.Debug.WriteLine(movie.ImgPath);
                file.SaveAs(Path.Combine(Server.MapPath("~/Images"), Path.GetFileName(file.FileName)));
                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movies movies = db.Movies.Find(id);
            if (movies == null)
            {
                return HttpNotFound();
            }
            return View(movies);
        }

        // POST: Movies/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性。有关
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MovieName,Genre,Description,Duration,Price,ImgPath")] Movies movies)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movies).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movies);
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movies movies = db.Movies.Find(id);
            if (movies == null)
            {
                return HttpNotFound();
            }
            return View(movies);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Movies movies = db.Movies.Find(id);
            db.Movies.Remove(movies);
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
