using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using POSSystem.Domain.Entities;

namespace POSSystem.Persistence.Configuration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Phone).IsRequired();
            builder.Property(x => x.Address).HasMaxLength(255);
            builder.HasMany(x => x.Orders).WithOne(x => x.Customer).HasForeignKey(x => x.CustomerId);
        }
    }
}
