﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWorkoutTracker.Models
{
    public class Food
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Kcal { get; set; }
        public string PicUrl { get; set; }
        public List<Food> foods { get; set; }
        public List<Person> people { get; set; }
        
        public Food()
        {
            foods =  new List<Food>();
            people = new List<Person>();
        }
        
    }
}