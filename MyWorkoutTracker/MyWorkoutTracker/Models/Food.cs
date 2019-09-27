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
        public int Kcal { get; set; }
        public int Count { get; set; }
        public string PicUrl { get; set; }

    }
}