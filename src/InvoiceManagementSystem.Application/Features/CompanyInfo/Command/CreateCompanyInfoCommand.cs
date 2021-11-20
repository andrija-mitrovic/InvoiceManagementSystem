using MediatR;

namespace InvoiceManagementSystem.Application.Features.CompanyInfo.Command
{
    public class CreateCompanyInfoCommand : IRequest<Unit>
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string BankAccount { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
