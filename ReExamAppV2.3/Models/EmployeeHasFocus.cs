using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReExamAppV2._3.Models
{
    public class EmployeeHasFocus
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int RoleId { get; set; }
        public DateTime YearlyFocus { get; set; }

        public virtual CompanyRole CompanyRole { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}