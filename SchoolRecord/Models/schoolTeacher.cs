using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolRecord.Models
{
    public class schoolTeacher
    {
        public int id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }


        [Display(Name = "Contact")]
        public string Contact { get; set; }


        [Display(Name = "Experience")]
        public string Experience { get; set; }


        [Display(Name = "Subject ")]
        public string Subject { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

    }
}
