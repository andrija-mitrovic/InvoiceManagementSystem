using InvoiceManagementSystem.Domain.Common;
using InvoiceManagementSystem.Domain.Enums;
using System;
using System.Collections.Generic;

namespace InvoiceManagementSystem.Domain.Entities
{
    public class Invoice : AuditEntity<int>
    {
        public string InvoiceNumber { get; set; }
        public string Logo { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime Date { get; set; }
        public string PaymentTerms { get; set; }
        public DateTime? DueDate { get; set; }
        public double Discount { get; set; }
        public DiscountType DiscountType { get; set; }
        public double Tax { get; set; }
        public TaxType TaxType { get; set; }
        public double AmountPaid { get; set; }
        public ICollection<InvoiceItem> InvoiceItems { get; set; } = new List<InvoiceItem>();
    }
}
