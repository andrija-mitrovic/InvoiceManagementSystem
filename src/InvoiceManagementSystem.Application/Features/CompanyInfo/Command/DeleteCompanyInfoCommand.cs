using MediatR;

namespace InvoiceManagementSystem.Application.Features.CompanyInfo.Command
{
    public class DeleteCompanyInfoCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
