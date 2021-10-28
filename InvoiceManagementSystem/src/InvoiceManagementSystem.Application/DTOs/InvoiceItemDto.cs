namespace InvoiceManagementSystem.Application.DTOs
{
    public class InvoiceItemDto
    {
        public string Item { get; set; }
        public double Quantity { get; set; }
        public double Rate { get; set; }
        public double Amount
        {
            get
            {
                return Quantity * Rate;
            }
        }
    }
}
