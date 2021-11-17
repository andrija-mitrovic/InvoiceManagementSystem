using InvoiceManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvoiceManagementSystem.Infrastructure.Data.Configurations
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.Property(c => c.InvoiceNumber).HasMaxLength(255);
            builder.Property(c => c.Logo).HasMaxLength(255);
            builder.Property(c => c.From).HasMaxLength(50);
            builder.Property(c => c.To).HasMaxLength(50);
        }
    }
}
