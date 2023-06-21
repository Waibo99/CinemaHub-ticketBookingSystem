using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CinemaHubFinalProject.Models
{
    public class CreateMovieViewModel
    {
        [DataType(DataType.Upload)]
        [Display(Name = "Upload File")]
        [Required(ErrorMessage = "Please choose file to upload.")]
        public string file { get; set; }
        public string MovieName { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public Nullable<int> Duration { get; set; }
        public Nullable<int> Price { get; set; }
        public string ImgPath { get; set; }
    }
}