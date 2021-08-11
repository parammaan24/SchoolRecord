using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolRecord.Data;
using SchoolRecord.Models;

namespace SchoolRecord.Pages.Admission
{
    public class DeleteModel : PageModel
    {
        private readonly SchoolRecord.Data.SchoolRecordContext _context;

        public DeleteModel(SchoolRecord.Data.SchoolRecordContext context)
        {
            _context = context;
        }

        [BindProperty]
        public schoolAdminssion schoolAdminssion { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            schoolAdminssion = await _context.schoolAdminssion.FirstOrDefaultAsync(m => m.id == id);

            if (schoolAdminssion == null)
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

            schoolAdminssion = await _context.schoolAdminssion.FindAsync(id);

            if (schoolAdminssion != null)
            {
                _context.schoolAdminssion.Remove(schoolAdminssion);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
