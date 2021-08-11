using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolRecord.Data;
using SchoolRecord.Models;

namespace SchoolRecord.Pages.Contact
{
    public class DeleteModel : PageModel
    {
        private readonly SchoolRecord.Data.SchoolRecordContext _context;

        public DeleteModel(SchoolRecord.Data.SchoolRecordContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Query Query { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Query = await _context.Query.FirstOrDefaultAsync(m => m.id == id);

            if (Query == null)
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

            Query = await _context.Query.FindAsync(id);

            if (Query != null)
            {
                _context.Query.Remove(Query);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
