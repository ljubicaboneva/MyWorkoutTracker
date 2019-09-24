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

    public class PeopleController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();


        // GET: People
        [Authorize(Roles = "Administrator")]
        public ActionResult Index()
        {

            return View(db.People.ToList());
        }
        public ActionResult Exercise()
        {
             return View();
        }
        //[HttpPost]
        //public ActionResult Exercise()
        //{
        //    int id = (int)Session["ID"];
        //    Person person = db.People.Find(id);
        //    return View();
        //}

        [HttpPost]
        public ActionResult MoreInfo()
        {
            int id = (int)Session["id"];
            Person person = db.People.Find(id);
            string info = Request["info"];
            if (info != null)
            {
                person.Info = info;
                db.SaveChanges();

            }
            
            
            return RedirectToAction("Details/" + person.id, "People");
        }

        // GET: People/Details/5
        [Authorize(Roles = "Administrator,User,Other")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.People.Find(id);
            Session["id"] = id;
            
            
            //var sessionValue = Session["MoreInfo"];
            //if (Session["MoreInfo"].ToString() != "")
            //{
            //    person.Info = Session["MoreInfo"].ToString();
            //    Session["MoreInfo"] = "";
            //}
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }


        //[HttpPost]
        //public ActionResult Details(Person person)
        //{
            
        //    //var path = "";
        //    //if (file != null)
        //    //{
        //    //    if (file.ContentLength > 0)
        //    //    {
        //    //        //for checking uploaded file imaage or not
        //    //        if (Path.GetExtension(file.FileName).ToLower() == ".jpg"
        //    //               || Path.GetExtension(file.FileName).ToLower() == ".png"
        //    //                || Path.GetExtension(file.FileName).ToLower() == ".gif"
        //    //                || Path.GetExtension(file.FileName).ToLower() == ".jpeg")
        //    //        {
        //    //            path = Path.Combine(Server.MapPath("~/Content/Images"), file.FileName);
        //    //            file.SaveAs(path);
        //    //            ViewBag.UploadSuccess = true;
        //    //        }
        //    //    }
        //    //}

        //    return View();
        //}
        // GET: People/Create
        [Authorize(Roles = "Other")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: People/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Other")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,FirstName,LastName,Years,Gender,Email,Role,Info,PicUrl")] Person person)
        {
            if (ModelState.IsValid)
            {
                db.Entry(person).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details/" + person.id, "People");
            }

            return View(person);
        }


        // GET: People/Edit/5
        [Authorize(Roles = "Administrator,User,Other")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Person person = db.People.Find(id);


            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: People/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Administrator,User,Other")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,FirstName,LastName,Years,Gender,Email,Role,Info,PicUrl")] Person person)
        {
            if (ModelState.IsValid)
            {
                if (person.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(person.ImageUpload.FileName);
                    string extension = Path.GetExtension(person.ImageUpload.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssff") + extension;
                    person.PicUrl = fileName;
                    person.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/AppFile/Images"), fileName));
                    db.Entry(person).State = EntityState.Modified;
                    db.SaveChanges();
                    var result = "Successfully added";
                    return RedirectToAction("Details/" + person.id, "People");
                }

            }
            return View(person);
        }
 
        //[HttpPost]
        //public ActionResult AddImage()
        //{
        //    var upload = Request["ImageUpload"];
        //    int idPerson = (int)Session["id"];
        //    Person person = db.People.Find(idPerson);
        //    //string fileName = Path.GetFileNameWithoutExtension(person.ImageUpload.FileName);
        //        //string extension = Path.GetExtension(person.ImageUpload.FileName);
        //        string fileName = upload;
        //        person.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/Images"), fileName));
        //        person.PicUrl = fileName;
        //        db.SaveChanges();
        //    return RedirectToAction("Index");

        //}

        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.People.Find(id);
            foreach (ApplicationUser p in db.Users)
            {
                if (person.Email == p.Email)
                {
                    db.Users.Remove(p);
                }
            }
            if (person == null)
            {
                return HttpNotFound();
            }

            db.People.Remove(person);

            db.SaveChanges();
            return RedirectToAction("Index");
        }



        //// GET: People/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Person person = db.People.Find(id);
        //    if (person == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(person);
        //}

        //// POST: People/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Person person = db.People.Find(id);
        //    db.People.Remove(person);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        [Authorize(Roles = "Administrator")]
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
