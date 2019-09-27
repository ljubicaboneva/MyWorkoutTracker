﻿using MyWorkoutTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWorkoutTracker.Controllers
{
    public class FoodsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Foods
        public ActionResult Index()
        {
            var model = new Food();

            foreach (Food f in db.Foods)
            {
                model.foods.Add(f);
            }
            return View(model);
        }
       
    }
}