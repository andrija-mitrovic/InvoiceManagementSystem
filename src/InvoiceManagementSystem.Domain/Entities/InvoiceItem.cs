using InvoiceManagementSystem.Domain.Common;

namespace InvoiceManagementSystem.Domain.Entities
{
    public class InvoiceItem : AuditEntity<int>
    {
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
        public string Item { get; set; }
        public double Quantity { get; set; }
        public double Rate { get; set; }
    }
}
