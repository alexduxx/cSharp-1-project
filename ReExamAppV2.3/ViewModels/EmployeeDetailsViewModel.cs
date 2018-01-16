using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ReExamAppV2._3.Models;

namespace ReExamAppV2._3.ViewModels
{
    public class EmployeeDetailsViewModel
    {

        public string Name { get; set; }
        public string Surname { get; set; }
        public int Phone { get; set; }
        public string Address { get; set; }
        public string Photo { get; set; }
        public string Email { get; set; }

        public List<EmployeeHasFocus> Focuses { get; set; }
        public List<CompanyRole> Roles { get; set; }

    }
}