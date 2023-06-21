using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CinemaHubFinalProject.Models;
using Microsoft.AspNet.Identity;

namespace CinemaHubFinalProject.Controllers
{
    public class ReceiptsController : Controller
    {
        private Entities db = new Entities();
        // GET: Receipts
        public ActionResult Index(string userName)
        {
            List<Receipts> receipts = db.Receipts.Where(m => m.UserName == userName).ToList();
            return PartialView(receipts);
        }
    }
}