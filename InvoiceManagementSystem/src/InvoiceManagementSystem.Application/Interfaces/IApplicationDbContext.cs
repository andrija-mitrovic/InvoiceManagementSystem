using InvoiceManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Application.Interfaces
{
    public interface IApplicationDbContext
    {

        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<CompanyInfo> CompanyInfo { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
