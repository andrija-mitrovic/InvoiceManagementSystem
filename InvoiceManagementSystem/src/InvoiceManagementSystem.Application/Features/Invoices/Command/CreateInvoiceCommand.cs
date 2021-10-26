using InvoiceManagementSystem.Application.DTOs;
using MediatR;

namespace InvoiceManagementSystem.Application.Features.Invoices.Command
{
    public class CreateInvoiceCommand : IRequest<Unit>
    {
        public InvoiceDto Invoice { get; set; }
    }
}
