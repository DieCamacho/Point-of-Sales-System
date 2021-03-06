﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using POS.Models;

namespace POS.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<POS.Models.Inventory> Inventory { get; set; }

        public DbSet<POS.Models.Product> Product { get; set; }

        public DbSet<POS.Models.Customer> Customer { get; set; }

        public DbSet<POS.Models.Supplier> Supplier { get; set; }

        public DbSet<POS.Models.Employee> Employee { get; set; }

        public DbSet<POS.Models.Store> Store { get; set; }

        public DbSet<POS.Models.Sup_Trans> Sup_Trans { get; set; }

        public DbSet<POS.Models.Sales> Sales { get; set; }
    }
}
