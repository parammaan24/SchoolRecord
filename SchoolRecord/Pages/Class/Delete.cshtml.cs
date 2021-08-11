using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolRecord.Data;
using SchoolRecord.Models;

namespace SchoolRecord.Pages.Class
{
    public class DeleteModel : PageModel
    {
        private readonly SchoolRecord.Data.SchoolRecordContext _context;

        public DeleteModel(SchoolRecord.Data.SchoolRecordContext context)
        {
            _context = context;
        }

        [BindProperty]
        public schoolClass schoolClass { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            schoolClass = await _context.schoolClass.FirstOrDefaultAsync(m => m.id == id);

            if (schoolClass == null)
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

            schoolClass = await _context.schoolClass.FindAsync(id);

            if (schoolClass != null)
            {
                _context.schoolClass.Remove(schoolClass);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
