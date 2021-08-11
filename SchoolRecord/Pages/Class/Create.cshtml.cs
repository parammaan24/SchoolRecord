using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolRecord.Data;
using SchoolRecord.Models;

namespace SchoolRecord.Pages.Class
{
    public class CreateModel : PageModel
    {
        private readonly SchoolRecord.Data.SchoolRecordContext _context;

        public CreateModel(SchoolRecord.Data.SchoolRecordContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public schoolClass schoolClass { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.schoolClass.Add(schoolClass);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
