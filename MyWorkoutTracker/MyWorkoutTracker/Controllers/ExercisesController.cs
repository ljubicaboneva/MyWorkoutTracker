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
        //public ActionResult Exercise()
        //{
        //    List<Exercise> lista = new List<Exercise>();
        //    foreach(Exercise e in db.Exercises)
        //    {
        //        lista.Add(e);
        //    }

        //    return View(lista);
        //}
        [HttpPost]
        public ActionResult Add()
        {

            return View();
        }
        
        public ActionResult Add(int? id)
        {
            int idd = (int)Session["ID"];
            Person person = db.People.Find(idd);
            Exercise exercise = db.Exercises.Find(id);
            person.Exercises.Add(exercise);
            db.SaveChanges();
            return RedirectToAction("Exercises","Index");
        }

        [HttpPost]
        public ActionResult Exercise()
        {
            int id = (int)Session["ID"];
            Person person = db.People.Find(id);

            //while (true)
            //{
            //    var e = db.Exercises.FirstOrDefault(z => z.isSelected == false);
            //    db.People.FirstOrDefault(z => z.id == id).Exercises.Add(e);
            //    db.Exercises.FirstOrDefault(z => z.isSelected == false).isSelected = true;
            //    db.SaveChanges();
            //    if (db.Exercises.FirstOrDefault(z => z.isSelected == false) == null)
            //    {
            //        break;
            //    }

            //}
            //foreach(var e in db.Exercises)
            //{
            //    e.isSelected = false;
            //}
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

            return RedirectToAction("Details/" + id, "People");
        }
    }
}