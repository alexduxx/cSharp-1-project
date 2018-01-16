using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReExamAppV2._3.Models
{
    public class Experience
    {
        public int Id { get; set; }
        public int CompanyRoleId { get; set; }
        public string UserId { get; set; }
        public string Level { get; set; }
        public int YearsOfExperience { get; set; }

        public virtual CompanyRole CompanyRole { get; set; }
        public virtual ApplicationUser User { get; set; }


    }
}