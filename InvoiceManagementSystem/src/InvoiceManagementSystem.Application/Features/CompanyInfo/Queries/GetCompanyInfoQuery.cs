using MediatR;

namespace InvoiceManagementSystem.Application.Features.CompanyInfo.Queries
{
    public class GetCompanyInfoQuery : IRequest<Domain.Entities.CompanyInfo>
    {
    }
}
