using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWorkoutTracker.Models
{
    public class Exercise
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool isSelected { get; set; }

    }
}