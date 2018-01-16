using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ReExamAppV2._3.Models;

namespace ReExamAppV2._3.ViewModels
{
    public class RolesViewModel
    {
        public string UserId { get; set; }
        public CompanyRole CompanyRole { get; set; }
        public List<ApplicationUser> Users { get; set; }
        public List<CompanyRole> ListOfCompanyRoles { get; set; }
        public List<EmployeeHasFocus> ListOfEmployeeHasFocuses { get; set; }
    }
}