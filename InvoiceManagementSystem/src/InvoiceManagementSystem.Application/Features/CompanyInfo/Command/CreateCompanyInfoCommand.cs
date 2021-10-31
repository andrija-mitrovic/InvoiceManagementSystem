using MediatR;

namespace InvoiceManagementSystem.Application.Features.CompanyInfo.Command
{
    public class CreateCompanyInfoCommand : IRequest<Unit>
    {
        public Domain.Entities.CompanyInfo CompanyInfo { get; set; }
    }
}
