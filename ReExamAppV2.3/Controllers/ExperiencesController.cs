using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using ReExamAppV2._3.Models;

namespace ReExamAppV2._3.Controllers
{
    public class ExperiencesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Experiences
        public ActionResult Index()
        {
            var experiences = db.Experiences.Include(e => e.CompanyRole).Include(e => e.User);
            return View(experiences.ToList());
        }

        // GET: Experiences/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Experience experience = db.Experiences.Find(id);
            if (experience == null)
            {
                return HttpNotFound();
            }
            return View(experience);
        }

        // GET: Experiences/Create
        public ActionResult Create(int? id)
        {
            
            List<string> experienceLevel = new List<string>();

            experienceLevel.Add("Beginner");
            experienceLevel.Add("Intermediate");
            experienceLevel.Add("Advanced");
            experienceLevel.Add("PRO");

           
                ViewBag.CompanyRoleId = new SelectList(db.CompanyRoles, "Id", "Name");
                ViewBag.UserId = new SelectList(db.Users, "Id", "Name");
                ViewBag.Level = new SelectList(experienceLevel, experienceLevel);
            
           

           
           
            return View();
        }

        // POST: Experiences/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CompanyRoleId,UserId,Level,YearsOfExperience")] Experience experience)
        {
            if (ModelState.IsValid)
            {
                db.Experiences.Add(experience);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            List<string> experienceLevel = new List<string>();

            experienceLevel.Add("Beginner");
            experienceLevel.Add("Intermediate");
            experienceLevel.Add("Advanced");
            experienceLevel.Add("PRO");





            ViewBag.CompanyRoleId = new SelectList(db.CompanyRoles, "Id", "Name", experience.CompanyRoleId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", experience.UserId);
            ViewBag.Level = new SelectList(experienceLevel, experienceLevel, experience.Level);

            return View(experience);
        }

        // GET: Experiences/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Experience experience = db.Experiences.Find(id);
            if (experience == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyRoleId = new SelectList(db.CompanyRoles, "Id", "Name", experience.CompanyRoleId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", experience.UserId);
            return View(experience);
        }

        // POST: Experiences/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CompanyRoleId,UserId,Level,YearsOfExperience")] Experience experience)
        {
            if (ModelState.IsValid)
            {
                db.Entry(experience).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyRoleId = new SelectList(db.CompanyRoles, "Id", "Name", experience.CompanyRoleId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", experience.UserId);
            return View(experience);
        }

        // GET: Experiences/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Experience experience = db.Experiences.Find(id);
            if (experience == null)
            {
                return HttpNotFound();
            }
            return View(experience);
        }

        // POST: Experiences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Experience experience = db.Experiences.Find(id);
            db.Experiences.Remove(experience);
            db.SaveChanges();
            return RedirectToAction("Index");
        }






        public ActionResult SetAchievement(int id)
        {
            List<string> experienceLevel = new List<string>();

            experienceLevel.Add("Beginner");
            experienceLevel.Add("Intermediate");
            experienceLevel.Add("Advanced");
            experienceLevel.Add("PRO");

            var role = db.CompanyRoles.Find(id);
           

            ViewBag.CompanyRoleId = id;
            ViewBag.UserId = User.Identity.GetUserId();
            ViewBag.Level = new SelectList(experienceLevel, experienceLevel);
            ViewBag.RoleName = role.Name;
            ViewBag.UserName = User.Identity.GetUserName();

            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SetAchievement([Bind(Include = "Id,CompanyRoleId,UserId,Level,YearsOfExperience")] Experience experience)
        {
            if (ModelState.IsValid)
            {
                db.Experiences.Add(experience);
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            return View(experience);
        }
        


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
