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
using ReExamAppV2._3.ViewModels;

namespace ReExamAppV2._3.Controllers
{
   
    public class CompanyRolesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CompanyRoles
        public ActionResult Index()
        {
            var currentUser = User.Identity.GetUserId();

            var viewModel = new RolesViewModel();

            viewModel.ListOfCompanyRoles = db.CompanyRoles.ToList();
            viewModel.ListOfEmployeeHasFocuses = db.EmployeeHasFocuses.ToList();
            viewModel.UserId = currentUser;

            

            return View(viewModel);
        }

       

        // GET: CompanyRoles/Details/5
        public ActionResult Details(int? id)
        {
           
            CompanyRole companyRole = db.CompanyRoles.Find(id);

            var viewModel = new RolesViewModel();
            viewModel.Users = db.Users.ToList();
            viewModel.CompanyRole = companyRole;
            viewModel.ListOfCompanyRoles = db.CompanyRoles.ToList();
            viewModel.ListOfEmployeeHasFocuses = db.EmployeeHasFocuses.ToList();

          
            
            return View(viewModel);
        }

        // GET: CompanyRoles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CompanyRoles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description")] CompanyRole companyRole)
        {
            if (ModelState.IsValid)
            {
                companyRole.CreationDate = DateTime.Now;
                db.CompanyRoles.Add(companyRole);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(companyRole);
        }

        // GET: CompanyRoles/Edit/5
        [Authorize(Roles = "CompanyAdministrator")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyRole companyRole = db.CompanyRoles.Find(id);
            if (companyRole == null)
            {
                return HttpNotFound();
            }
            return View(companyRole);
        }

        // POST: CompanyRoles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "CompanyAdministrator")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,CreationDate")] CompanyRole companyRole)
        {
            if (ModelState.IsValid)
            {
                db.Entry(companyRole).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(companyRole);
        }

        // GET: CompanyRoles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyRole companyRole = db.CompanyRoles.Find(id);
            if (companyRole == null)
            {
                return HttpNotFound();
            }
            return View(companyRole);
        }

        // POST: CompanyRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CompanyRole companyRole = db.CompanyRoles.Find(id);
            db.CompanyRoles.Remove(companyRole);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        public ActionResult TakeRole(int id, EmployeesViewModel newFocus)
        {
            var currentUser = User.Identity.GetUserId();
            List<EmployeeHasFocus> currentUserHasFocuses = db.EmployeeHasFocuses.Where(x => x.UserId == currentUser).ToList();

           

            if (currentUserHasFocuses.Count < 3)
            {
                db.EmployeeHasFocuses.Add(new EmployeeHasFocus() { RoleId = id, UserId = currentUser, YearlyFocus = DateTime.Now.AddYears(1) });
                db.SaveChanges();
            }
            
          


            return RedirectToAction("Index");
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
