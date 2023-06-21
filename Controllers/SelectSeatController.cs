using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CinemaHubFinalProject.Models;
using Microsoft.AspNet.Identity;

namespace CinemaHubFinalProject.Controllers
{
    public class SelectSeatController : Controller
    {
        private Entities db = new Entities();
        // GET: SelectSeat
        public ActionResult Index()
        {
            return View();
        }

        // GET: SelectSeat/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SelectSeat/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SelectSeat/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SelectSeat/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SelectSeat/Edit/5
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

        // GET: SelectSeat/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SelectSeat/Delete/5
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

        public PartialViewResult getShowTimeByMovieName(string MovieName)
        {
            SelectSeatViewModel model = new SelectSeatViewModel();
            model.ShowList = db.Shows.Where(m => m.MovieName == MovieName).ToList();
            return PartialView(model);
        }

        public PartialViewResult Seats(int id = 0)
        {
            Shows model = new Shows();
            model = db.Shows.Find(id);
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult ConfirmSeat(string amount, string selectedSeat, [Bind(Include = "ShowID,MovieName,ShowTime,Seat0,Seat1,Seat2,Seat3,Seat4,Seat5,Seat6,Seat7,Seat8,Seat9,Seat10,Seat11,Seat12,Seat13,Seat14,Seat15,Seat16,Seat17,Seat18,Seat19,Seat20,Seat21,Seat22,Seat23,Seat24,Seat25")] Shows shows)
        {
            var userId = User.Identity.GetUserId();
            AspNetUsers user = db.AspNetUsers.Find(userId);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            if (ModelState.IsValid)
            {
                db.Entry(shows).State = EntityState.Modified;
                db.SaveChanges();
            }

            Random rnd = new Random();
            Receipts newReceipt = new Receipts();
            newReceipt.ShowID = shows.ShowID;
            newReceipt.TotalAmount = Convert.ToInt32(amount);
            System.Diagnostics.Debug.WriteLine("total amount=", newReceipt.TotalAmount);
            newReceipt.MovieName = shows.MovieName;
            newReceipt.Seats = selectedSeat;
            newReceipt.BuyTime = DateTime.Now;
            newReceipt.ReceiptsID = rnd.Next(1, 100000);
            newReceipt.UserName = user.UserName;
            newReceipt.UserID = userId;
            db.Receipts.Add(newReceipt);
            db.SaveChanges();
            System.Diagnostics.Debug.WriteLine("receipt successfully added!");
            return RedirectToAction("Index", "Manage");
        }
    }
}