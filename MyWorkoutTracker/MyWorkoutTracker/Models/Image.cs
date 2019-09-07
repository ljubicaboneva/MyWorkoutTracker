using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyWorkoutTracker.Models
{
    public class Image
    {
        public int ImageID { get; set; }
        public string Title { get; set; }
        [Display(Name="Upolad File")]
        public string ImagePath { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
    }
}