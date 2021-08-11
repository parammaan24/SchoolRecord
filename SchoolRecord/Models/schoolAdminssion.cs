using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolRecord.Models
{
    public class schoolAdminssion
    {

        public int id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Father Name")]
        public string fatherName { get; set; }

        [Display(Name = "Contact")]
        public string Contact { get; set; }

        [Display(Name = "Class")]
        public string sClass { get; set; }

        public schoolClass school_Class { get; set; }
    }
}
