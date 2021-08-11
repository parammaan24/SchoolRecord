using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolRecord.Data;
using SchoolRecord.Models;

namespace SchoolRecord.Pages.Admission
{
    public class EditModel : PageModel
    {
        private readonly SchoolRecord.Data.SchoolRecordContext _context;

        public EditModel(SchoolRecord.Data.SchoolRecordContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(schoolAdminssion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!schoolAdminssionExists(schoolAdminssion.id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool schoolAdminssionExists(int id)
        {
            return _context.schoolAdminssion.Any(e => e.id == id);
        }
    }
}
