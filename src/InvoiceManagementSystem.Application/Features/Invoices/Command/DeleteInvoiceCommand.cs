using MediatR;

namespace InvoiceManagementSystem.Application.Features.Invoices.Command
{
    public class DeleteInvoiceCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
