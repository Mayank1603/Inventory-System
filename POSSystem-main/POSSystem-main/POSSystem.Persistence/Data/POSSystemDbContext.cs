using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using POSSystem.Domain.Entities;

namespace POSSystem.Persistence.Data
{
    public class POSSystemDbContext : DbContext
    {
        public POSSystemDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(POSSystemDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
