
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using ReExamAppV2._3.Models;
using ReExamAppV2._3.ViewModels;

namespace ReExamAppV2._3.Controllers
{
    
    public class EmployeesController : Controller
    {
        
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Employees
        public ActionResult Index()
        {
            var employees = db.Users.Where(x => x.Email != "admin@admin.com").ToList();
            var roles = db.CompanyRoles.ToList();
            var currentUser = User.Identity.GetUserId();

            var userHasFocuses = db.EmployeeHasFocuses.Where(x => x.User.Id == currentUser).ToList();

            var viewModel = new EmployeesViewModel();

            viewModel.Focuses = userHasFocuses;
            viewModel.Roles = roles;
            viewModel.Users = employees;
           
 
            return View(viewModel);
        }


        

       
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);

            var viewModel = new EmployeeDetailsViewModel();

            viewModel.Name = applicationUser.Name;
            viewModel.Surname = applicationUser.Surname;
            viewModel.Phone = applicationUser.Phone;
            viewModel.Address = applicationUser.Address;
            viewModel.Photo = applicationUser.Photo;
            viewModel.Email = applicationUser.Email;
            viewModel.Focuses = db.EmployeeHasFocuses.Where(x => x.User.Id == applicationUser.Id).ToList();
            viewModel.Roles = db.CompanyRoles.ToList();


           
            return View(viewModel);
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
