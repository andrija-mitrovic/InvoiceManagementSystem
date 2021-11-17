using InvoiceManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvoiceManagementSystem.Infrastructure.Data.Configurations
{
    public class CompanyInfoConfiguration : IEntityTypeConfiguration<CompanyInfo>
    {
        public void Configure(EntityTypeBuilder<CompanyInfo> builder)
        {
            builder.Property(c => c.Name).HasMaxLength(255);
            builder.Property(c => c.PhoneNumber).HasMaxLength(20);
            builder.Property(c => c.Email).HasMaxLength(40);
            builder.Property(c => c.BankAccount).HasMaxLength(255);
            builder.Property(c => c.Address).HasMaxLength(50);
            builder.Property(c => c.ZipCode).HasMaxLength(20);
            builder.Property(c => c.City).HasMaxLength(50);
            builder.Property(c => c.Country).HasMaxLength(50);
        }
    }
}
