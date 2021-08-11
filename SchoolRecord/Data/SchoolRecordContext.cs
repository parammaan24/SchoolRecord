using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolRecord.Models;

namespace SchoolRecord.Data
{
    public class SchoolRecordContext : DbContext
    {
        public SchoolRecordContext (DbContextOptions<SchoolRecordContext> options)
            : base(options)
        {
        }

        public DbSet<SchoolRecord.Models.schoolClass> schoolClass { get; set; }

        public DbSet<SchoolRecord.Models.schoolTeacher> schoolTeacher { get; set; }

        public DbSet<SchoolRecord.Models.schoolAdminssion> schoolAdminssion { get; set; }

        public DbSet<SchoolRecord.Models.Query> Query { get; set; }
    }
}
