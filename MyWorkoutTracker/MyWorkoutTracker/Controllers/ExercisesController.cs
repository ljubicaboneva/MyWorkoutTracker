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
    [Authorize(Roles = "Administrator,User")]
    public class ExercisesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Exercises
        public ActionResult Index()
        {
           return View(db.Exercises.ToList());
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
            return RedirectToAction("Details/" + id, "People");
        }

        
        public ActionResult Description(int? id)
        {
            Exercise model = db.Exercises.Find(id);

            return View(model);
        }
    }
}