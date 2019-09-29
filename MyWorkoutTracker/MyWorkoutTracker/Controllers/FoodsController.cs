using MyWorkoutTracker.Models;
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

        public ActionResult Add(int? id)
        {
            int idd = (int)Session["ID"];
            Person person = db.People.Find(idd);
            Food food = db.Foods.Find(id);
            food.IsSelected = true;
            db.SaveChanges();
            person.Foods.Add(food);
            db.SaveChanges();
            food.IsSelected = false;
            db.SaveChanges();
            return RedirectToAction("Foods", "Index");
        }
        [HttpPost]
        public ActionResult Food()
        {
            int id = (int)Session["ID"];
            Person person = db.People.Find(id);
            return RedirectToAction("Details/" + id, "People");
        }

        public ActionResult Description(int? id)
        {
            Food model = db.Foods.Find(id);

            return View(model);
        }
    }
}