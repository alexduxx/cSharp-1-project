using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReExamAppV2._3.Models
{
    public class CompanyRole
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual ICollection<EmployeeHasFocus> EmployeeFocuses { get; set; }
        public virtual ICollection<Experience> EmployeExperiences { get; set; }

    }
}