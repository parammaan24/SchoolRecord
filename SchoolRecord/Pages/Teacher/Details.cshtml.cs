using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolRecord.Data;
using SchoolRecord.Models;

namespace SchoolRecord.Pages.Teacher
{
    public class DetailsModel : PageModel
    {
        private readonly SchoolRecord.Data.SchoolRecordContext _context;

        public DetailsModel(SchoolRecord.Data.SchoolRecordContext context)
        {
            _context = context;
        }

        public schoolTeacher schoolTeacher { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            schoolTeacher = await _context.schoolTeacher.FirstOrDefaultAsync(m => m.id == id);

            if (schoolTeacher == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
