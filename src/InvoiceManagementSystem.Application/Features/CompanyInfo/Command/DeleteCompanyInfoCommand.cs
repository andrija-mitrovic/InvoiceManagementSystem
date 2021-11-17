using InvoiceManagementSystem.Application.Helpers;
using MediatR;

namespace InvoiceManagementSystem.Application.Features.CompanyInfo.Command
{
    public class DeleteCompanyInfoCommand : IRequest<Result<Unit>>
    {
        public int Id { get; set; }
    }
}
