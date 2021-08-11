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
    public class IndexModel : PageModel
    {
        private readonly SchoolRecord.Data.SchoolRecordContext _context;

        public IndexModel(SchoolRecord.Data.SchoolRecordContext context)
        {
            _context = context;
        }

        public IList<Query> Query { get;set; }

        public async Task OnGetAsync()
        {
            Query = await _context.Query.ToListAsync();
        }
    }
}
