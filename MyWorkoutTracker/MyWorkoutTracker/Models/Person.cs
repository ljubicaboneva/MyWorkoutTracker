using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyWorkoutTracker.Models
{
    public class Person
    {
        public int id { get; set; }
        
        [Display(Name="First Name")]
        [Required]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }
        [Required]
        public int Years { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public String Role { get; set; }
        public string Info { get; set; }
        public string PicUrl { get; set; }
        public List<Exercise> Exercises { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }
        
    }  
}