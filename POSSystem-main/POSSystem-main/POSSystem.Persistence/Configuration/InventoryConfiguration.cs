using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POSSystem.Domain.Entities;


namespace POSSystem.Persistence.Configuration
{
    public class InventoryConfiguration : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.ToTable("Inventories");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Stock).IsRequired();
            builder.Property(x => x.Price).IsRequired();

            builder.HasMany(x => x.Items)
                   .WithOne(x => x.Inventory)
                   .HasForeignKey(x => x.InventoryId);

            builder.HasMany(x => x.Orders)
                   .WithOne(x => x.Inventory)
                   .HasForeignKey(x => x.InventoryId);
        }
    }
}

