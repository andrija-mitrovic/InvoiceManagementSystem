using InvoiceManagementSystem.Application.DTOs;
using InvoiceManagementSystem.Application.Helpers;
using MediatR;

namespace InvoiceManagementSystem.Application.Features.Invoices.Command
{
    public class CreateInvoiceCommand : IRequest<Result<Unit>>
    {
        public InvoiceDto Invoice { get; set; }
    }
}
