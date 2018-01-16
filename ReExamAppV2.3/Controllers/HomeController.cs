using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.EnterpriseServices;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using ReExamAppV2._3.Models;

namespace ReExamAppV2._3.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Authorize]
        public ActionResult Index()
        {
           
            var currentUser = User.Identity.GetUserId();
            ViewBag.User = db.Users.Find(currentUser);

            if (db.CompanyInfos.Any())
            {
                var companyInfo = db.CompanyInfos.First();
                return View(companyInfo);

            }
            else
            {

                var companyInfo = new CompanyInfo();
                companyInfo.CompanyName = "NOT SET";
                companyInfo.Address = "NOT SET";
                companyInfo.CVR = "NOT SET";
                companyInfo.CompanyDescription = "NOT SET";
                companyInfo.Logo = "http://www.bandartigiana.it/bnd/wp-content/uploads/2016/05/default-image.png";
                companyInfo.Phone = 00000000;
                companyInfo.Id = 1231223;
                return View(companyInfo);

            }

        }

        [Authorize(Roles = "CompanyAdministrator")]
        public ActionResult CreateCompanyInfo()
        { 

            return View();
        }

        [HttpPost]
        [Authorize(Roles = "CompanyAdministrator")]
        public ActionResult CreateCompanyInfo(CompanyInfo CompanyInfo, HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), _FileName);
                    CompanyInfo.Logo = "/UploadedFiles/" + _FileName;
                    file.SaveAs(_path);
                }
                ViewBag.Message = "File Uploaded Successfully!!";
                db.CompanyInfos.Add(CompanyInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Message = "File Upload failed!!";


            }

            return View();
        }

      



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        
    }
}