using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CinemaHubFinalProject.Models;
using Microsoft.AspNet.Identity;

namespace CinemaHubFinalProject.Controllers
{
    public class CommentsController : Controller
    {

        private Entities db = new Entities();
        // GET: Comments
        public ActionResult Index()
        {
            return View();
        }

        // GET: Comments/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        // POST: Comments/Create
        [HttpPost]
        public ActionResult Create(Comments comment,string com)
        {
            Random rnd = new Random();
            var userId = User.Identity.GetUserId();
            AspNetUsers user = db.AspNetUsers.Find(userId);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }
            if (ModelState.IsValid)
            {
                comment.Comment = com;
                comment.PublishTime = DateTime.Now;
                comment.CommentID = rnd.Next(1,100000);
                comment.UserName = user.UserName;
                db.Comments.Add(comment);
                db.SaveChanges();
                System.Diagnostics.Debug.WriteLine("comment successfully added!");
                return RedirectToAction("Movie", "Home", new { id = comment.MovieName });
            }
            System.Diagnostics.Debug.WriteLine("comment failed");
            return RedirectToAction("GetCommentByMovieName", new { id = "Nope" });
        }

        // GET: Comments/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Comments/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Comments/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Comments/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public PartialViewResult GetCommentByMovieName(string id)
        {
            List<Comments> comments = db.Comments.Where(m => m.MovieName == id).ToList();
            ViewBag.ID = id;
            return PartialView(comments);
        }
    }
}
