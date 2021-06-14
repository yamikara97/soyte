using System;
using System.Collections.Generic;
using System.Text;
using HD_proj.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HD_proj.Data
{
    public class ApplicationDbContext
    : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        

        public DbSet<DanhmucFile> DanhmucFiles { get; set; }
        public DbSet<Cchn> Cchns { get; set; }
        public DbSet<Quyetdinh> Quyetdinhs { get; set; }
        public DbSet<Giaytotuythan> Giaytotuythans { get; set; }
        public DbSet<Gcndkkd> Gcndkkds { get; set; }
    }
}
