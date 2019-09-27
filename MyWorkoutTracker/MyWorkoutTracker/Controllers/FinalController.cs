using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyWorkoutTracker.Models;

namespace MyWorkoutTracker.Controllers
{
    public class FinalController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Final
        public ActionResult Index()
        {
            var id = (int)Session["ID"];
            Person person = db.People.Find(id);
            return View(person);
        }
    }
}