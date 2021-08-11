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
    public class IndexModel : PageModel
    {
        private readonly SchoolRecord.Data.SchoolRecordContext _context;

        public IndexModel(SchoolRecord.Data.SchoolRecordContext context)
        {
            _context = context;
        }

        public IList<schoolAdminssion> schoolAdminssion { get;set; }

        public async Task OnGetAsync()
        {
            schoolAdminssion = await _context.schoolAdminssion.ToListAsync();
        }
    }
}
