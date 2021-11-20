using MediatR;

namespace InvoiceManagementSystem.Application.Features.Invoices.Command
{
    public class EditInvoiceItemCommand : IRequest<Unit>
    {
        public int InvoiceId { get; set; }
        public int InvoiceItemId { get; set; }
        public string Item { get; set; }
        public double Quantity { get; set; }
        public double Rate { get; set; }
    }
}
