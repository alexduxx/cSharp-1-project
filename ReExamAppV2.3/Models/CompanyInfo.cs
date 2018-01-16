using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReExamAppV2._3.Models
{
    public class CompanyInfo
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string CompanyDescription { get; set; }
        public int Phone { get; set; }
        public string Logo { get; set; }
        public string Address { get; set; }
        public string CVR { get; set; }
        public string Email { get; set; }
    }
}