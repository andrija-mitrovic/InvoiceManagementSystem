using InvoiceManagementSystem.Application.Features.CompanyInfo.Command;
using InvoiceManagementSystem.Application.Features.CompanyInfo.Queries;
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
            return HandleResult(await Mediator.Send(new GetCompanyInfoQuery(), cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompanyInfo(CreateCompanyInfoCommand command, CancellationToken cancellationToken)
        {
            return HandleResult(await Mediator.Send(command, cancellationToken));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCompanyInfo(int id, EditCompanyInfoCommand command, CancellationToken cancellationToken)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            return HandleResult(await Mediator.Send(command, cancellationToken));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompanyInfo(int id, CancellationToken cancellationToken)
        {
            return HandleResult(await Mediator.Send(new DeleteCompanyInfoCommand { Id = id }, cancellationToken));
        }
    }
}
