using System;

namespace InvoiceManagementSystem.Domain.Common
{
    public class AuditEntity<T>
    {
        public T Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModified { get; set; }
    }
}
