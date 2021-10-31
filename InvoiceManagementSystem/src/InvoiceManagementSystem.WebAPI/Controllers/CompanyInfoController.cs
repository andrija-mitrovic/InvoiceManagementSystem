using InvoiceManagementSystem.Application.Features.CompanyInfo.Command;
using InvoiceManagementSystem.Application.Features.CompanyInfo.Queries;
using InvoiceManagementSystem.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.WebAPI.Controllers
{
    public class CompanyInfoController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetCompanyInfo(CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetCompanyInfoQuery(), cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompanyInfo(CompanyInfo companyInfo, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateCompanyInfoCommand { CompanyInfo = companyInfo }, cancellationToken));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCompanyInfo(int id, CompanyInfo companyInfo, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new EditCompanyInfoCommand { Id = id, CompanyInfo = companyInfo }, cancellationToken));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompanyInfo(int id, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new DeleteCompanyInfoCommand { Id = id }, cancellationToken));
        }
    }
}
