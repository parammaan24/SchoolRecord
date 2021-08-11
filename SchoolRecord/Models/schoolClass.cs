using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolRecord.Models
{
    public class schoolClass
    {
        public int id { get; set; }

        [Display(Name = " class Name")]
        public string Name { get; set; }


        [Display(Name = "Teacher Name ")]
        public string Contact { get; set; }


        [Display(Name = "Fees ")]
        public int Fees{ get; set; }

        public schoolTeacher teacher { get; set; }

    }
}
