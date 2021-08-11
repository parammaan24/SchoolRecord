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

namespace SchoolRecord.Pages.Class
{
    public class EditModel : PageModel
    {
        private readonly SchoolRecord.Data.SchoolRecordContext _context;

        public EditModel(SchoolRecord.Data.SchoolRecordContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(schoolClass).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!schoolClassExists(schoolClass.id))
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

        private bool schoolClassExists(int id)
        {
            return _context.schoolClass.Any(e => e.id == id);
        }
    }
}
