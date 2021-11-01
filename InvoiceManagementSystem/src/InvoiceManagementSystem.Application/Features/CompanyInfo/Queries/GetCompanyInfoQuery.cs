using InvoiceManagementSystem.Application.Helpers;
using MediatR;

namespace InvoiceManagementSystem.Application.Features.CompanyInfo.Queries
{
    public class GetCompanyInfoQuery : IRequest<Result<Domain.Entities.CompanyInfo>>
    {
    }
}
