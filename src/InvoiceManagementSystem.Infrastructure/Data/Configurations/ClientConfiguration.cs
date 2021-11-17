using InvoiceManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvoiceManagementSystem.Infrastructure.Data.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.Property(c => c.Name).HasMaxLength(255);
            builder.Property(c => c.Address).HasMaxLength(255);
            builder.Property(c => c.PhoneNumber).HasMaxLength(50);
            builder.Property(c => c.Email).HasMaxLength(40);
        }
    }
}
