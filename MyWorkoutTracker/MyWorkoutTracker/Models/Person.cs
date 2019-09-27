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
        public string Role { get; set; }
        public string Info { get; set; }
        public int exeId { get; set; }
        public string PicUrl { get; set; }
        public virtual ICollection<Exercise> Exercises { get; set; }
        public virtual ICollection<Food> Foods { get; set; }
        public Person()
        {
            Exercises = new List<Exercise>();
            Foods = new List<Food>();

        }
        
    }  
}