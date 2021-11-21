using MediatR;

namespace InvoiceManagementSystem.Application.Features.Invoices.Command
{
    public class DeleteInvoiceItemCommand : IRequest<Unit>
    {
        public int InvoiceId { get; set; }
        public int InvoiceItemId { get; set; }
    }
}
