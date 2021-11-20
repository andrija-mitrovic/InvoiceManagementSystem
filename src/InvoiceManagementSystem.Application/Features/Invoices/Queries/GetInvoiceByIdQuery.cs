using InvoiceManagementSystem.Application.DTOs;
using MediatR;

namespace InvoiceManagementSystem.Application.Features.Invoices.Queries
{
    public class GetInvoiceByIdQuery : IRequest<InvoiceDto>
    {
        public int Id { get; set; }
    }
}
