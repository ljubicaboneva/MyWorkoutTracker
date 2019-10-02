using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyWorkoutTracker.Models;

namespace MyWorkoutTracker.Controllers
{
    [Authorize(Roles = "User,Administrator")]
    public class FinalController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Final
        public ActionResult Index()
        {
            var id = (int)Session["ID"];
            Person person = db.People.Find(id);
            Session["ID"] = person.id;
            return View(person);
        }

        public ActionResult Delete()
        {
            var id = (int)Session["ID"];
            Person person = db.People.Find(id);

            person.Exercises.Clear();

            person.Foods.Clear();
            db.SaveChanges();

            return RedirectToAction("Details/" + person.id, "People");
        }
    }
}