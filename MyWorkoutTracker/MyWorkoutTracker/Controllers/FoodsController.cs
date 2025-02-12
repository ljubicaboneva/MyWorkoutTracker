﻿using MyWorkoutTracker.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWorkoutTracker.Controllers

{   [Authorize(Roles ="User,Administrator")]
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
        public ActionResult Picture()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Image(HttpPostedFileBase file)
        {
            int idFood = (int)Session["idFood"];
            Food food = db.Foods.Find(idFood);

            var path = "";
            if (file != null)
            {
                if (file.ContentLength > 0)
                {
                    //for checking uploaded file imaage or not
                    if (Path.GetExtension(file.FileName).ToLower() == ".jpg"
                           || Path.GetExtension(file.FileName).ToLower() == ".png"
                            || Path.GetExtension(file.FileName).ToLower() == ".gif"
                            || Path.GetExtension(file.FileName).ToLower() == ".jpeg")
                    {
                        path = Path.Combine(Server.MapPath("~/Images/Food"), file.FileName);
                        file.SaveAs(path);
                        food.PicUrl = file.FileName;
                        db.SaveChanges();
                    }
                }
            }
            
            return RedirectToAction("Index", "Foods");
        }

        public ActionResult Add(int? id)
        {
            int idd = (int)Session["ID"];
            Person person = db.People.Find(idd);
            Food food = db.Foods.Find(id);
            person.Foods.Add(food);
            
            db.SaveChanges();
           
            return RedirectToAction("Foods", "Index");
        }
        [HttpPost]
        public ActionResult Food()
        {
            int id = (int)Session["ID"];
            Person person = db.People.Find(id);
            Session["ID"] = person.id;
            return RedirectToAction("Details/" + id, "People");
        }

        public ActionResult Description(int? id)
        {
            Food model = db.Foods.Find(id);
            Session["idFood"] = model.id;
            return View(model);
        }


        [Authorize(Roles = "User,Administrator")]
        public ActionResult Create()
        {
            return View();
        }

    
        [HttpPost]
        [Authorize(Roles = "User,Administrator")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Name,Description,Kcal")] Food food)
        {

            if (ModelState.IsValid)
            {
                db.Foods.Add(food);
               
                db.SaveChanges();
                Session["idFood"] = food.id;
                return RedirectToAction("Picture", "Foods");
            }

            return View(food);
        }
        
      

    }
}