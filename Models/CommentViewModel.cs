using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaHubFinalProject.Models
{
    public class CommentViewModel
    {
        public int CommentID { get; set; }
        public string MovieName { get; set; }
        public string UserID { get; set; }
        public string UserName { get; set; }
        public Nullable<System.DateTime> PublishTime { get; set; }
        public string Comment { get; set; }
    }
}