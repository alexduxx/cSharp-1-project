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
    
    public class EmployeeHasFocusController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EmployeeHasFocus
        public ActionResult Index()
        {
            var currentUser = User.Identity.GetUserId();

            var viewModel = new RolesViewModel();

            viewModel.ListOfCompanyRoles = db.CompanyRoles.ToList();
            viewModel.ListOfEmployeeHasFocuses = db.EmployeeHasFocuses.ToList();
            viewModel.UserId = currentUser;
            viewModel.Users = db.Users.ToList();


            return View(viewModel);
        }

        // GET: EmployeeHasFocus/Details/5
        public ActionResult Details(int id)
        {
           
            EmployeeHasFocus employeeHasFocus = db.EmployeeHasFocuses.Find(id);

            var viewModel = new RolesViewModel();

            viewModel.ListOfCompanyRoles = db.CompanyRoles.ToList();

            foreach (var role in viewModel.ListOfCompanyRoles)
            {
                if (role.Id == employeeHasFocus.RoleId)
                {
                    viewModel.CompanyRole = role;
                }
                
            }
           

            viewModel.ListOfEmployeeHasFocuses = db.EmployeeHasFocuses.ToList();
            viewModel.Users = db.Users.ToList();
            
            
           
            return View(viewModel);
        }

      

  
        public ActionResult Delete(int? id)
        {
           
            
            EmployeeHasFocus employeeHasFocus = db.EmployeeHasFocuses.Find(id);
            db.EmployeeHasFocuses.Remove(employeeHasFocus);
            db.SaveChanges();
            return RedirectToAction("Index");

           
        }

        public ActionResult DeleteFocusFromRoles(int? id)
        {
            
            EmployeeHasFocus employeeHasFocus = db.EmployeeHasFocuses.Find(id);
            db.EmployeeHasFocuses.Remove(employeeHasFocus);
            db.SaveChanges();
            return RedirectToAction("Index","CompanyRoles");
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
