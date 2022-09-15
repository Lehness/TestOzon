using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace apiEmail.Models
{
    public class ApContext:DbContext
    {
        public DbSet<DbEmail> DbEmails { get; set; }
        public ApContext(DbContextOptions<ApContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
