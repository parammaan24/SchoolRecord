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
    public class DeleteModel : PageModel
    {
        private readonly SchoolRecord.Data.SchoolRecordContext _context;

        public DeleteModel(SchoolRecord.Data.SchoolRecordContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            schoolTeacher = await _context.schoolTeacher.FindAsync(id);

            if (schoolTeacher != null)
            {
                _context.schoolTeacher.Remove(schoolTeacher);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
