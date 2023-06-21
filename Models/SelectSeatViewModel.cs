using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CinemaHubFinalProject.Models;

namespace CinemaHubFinalProject.Models
{
    public class SelectSeatViewModel
    {
        public List<Shows> ShowList { get; set; }
        public Shows CurrentShow { get; set; }

    }
}