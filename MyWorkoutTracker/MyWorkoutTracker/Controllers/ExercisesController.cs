using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyWorkoutTracker.Models;

namespace MyWorkoutTracker.Controllers
{
    public class ExercisesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Exercises
        public ActionResult Index()
        {
            return View(db.Exercises.ToList());
        }
        [HttpPost]
        public ActionResult Exercise()
        {
            int id = (int)Session["ID"];
            Person person = db.People.Find(id);

            while(db.Exercises.FirstOrDefault(z => z.isSelected == false) != null)
            {
                Exercise e = new Exercise();
                db.People.FirstOrDefault(z => z.id == id).Exercises.Add(db.Exercises.FirstOrDefault(z => z.isSelected == false));
                e = db.Exercises.FirstOrDefault(z => z.isSelected == false);
                db.People.FirstOrDefault(z => z.id == id).Exercises.Add(e);
                db.Exercises.FirstOrDefault(z => z.isSelected == false).isSelected = true;
            }
            //foreach (var e in db.Exercises)
            //{
            //    if (e.isSelected==false)
            //    {
                    //try
                    //{
                    //    var workout = new Exercise();
                    //    {
                    //        workout.Name = e.Name;
                    //        workout.Description = e.Description;
                    //        workout.isSelected = false;
                    //        workout.id = e.id;

                    //    };
                    //    person.Exercises.Add(workout);
                    //}
                    //catch { }
                   // e.isSelected = true;
            //    }
            //}


            db.SaveChanges();
            return RedirectToAction("Details/" + id, "People");
        }
    }
}