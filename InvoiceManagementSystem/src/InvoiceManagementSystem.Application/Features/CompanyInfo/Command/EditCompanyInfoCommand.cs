using MediatR;

namespace InvoiceManagementSystem.Application.Features.CompanyInfo.Command
{
    public class EditCompanyInfoCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public Domain.Entities.CompanyInfo CompanyInfo { get; set; }
    }
}
