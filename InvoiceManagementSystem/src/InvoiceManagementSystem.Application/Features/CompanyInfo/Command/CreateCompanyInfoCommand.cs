using InvoiceManagementSystem.Application.Helpers;
using MediatR;

namespace InvoiceManagementSystem.Application.Features.CompanyInfo.Command
{
    public class CreateCompanyInfoCommand : IRequest<Result<Unit>>
    {
        public Domain.Entities.CompanyInfo CompanyInfo { get; set; }
    }
}
