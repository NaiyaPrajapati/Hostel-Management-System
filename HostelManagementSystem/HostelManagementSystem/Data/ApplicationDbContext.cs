using HostelManagementSystem.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HostelManagementSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<GetPass> GetPass { get; set; }
        public DbSet<Notice> Notice { get; set; }
        public DbSet<Complaint> Complaint { get; set; }
        public DbSet<Menu> Menu { get; set; }
    }
}
