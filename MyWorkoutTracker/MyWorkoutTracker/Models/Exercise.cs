using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;

namespace MyWorkoutTracker.Models
{
    public class Exercise
    {
        
        public int id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Person> peoples { get; set; }
        public string PicUrl { get; set; }
        
    }
}