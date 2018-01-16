using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ReExamAppV2._3.Models;

namespace ReExamAppV2._3.ViewModels
{
    public class EmployeesViewModel
    {
        public string EmployeeId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<EmployeeHasFocus> Focuses { get; set; }
        public List<CompanyRole> Roles { get; set; }
        public List<ApplicationUser> Users { get; set; }



    }
}