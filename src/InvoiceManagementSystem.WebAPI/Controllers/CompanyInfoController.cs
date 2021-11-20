using InvoiceManagementSystem.Application.Features.CompanyInfo.Command;
using InvoiceManagementSystem.Application.Features.CompanyInfo.Queries;
using InvoiceManagementSystem.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.WebAPI.Controllers
{
    public class CompanyInfoController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<CompanyInfo>> GetCompanyInfo(CancellationToken cancellationToken)
        {
            return await Mediator.Send(new GetCompanyInfoQuery(), cancellationToken);
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> CreateCompanyInfo(CreateCompanyInfoCommand command, CancellationToken cancellationToken)
        {
            return await Mediator.Send(command, cancellationToken);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> UpdateCompanyInfo(int id, EditCompanyInfoCommand command, CancellationToken cancellationToken)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command, cancellationToken);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> DeleteCompanyInfo(int id, CancellationToken cancellationToken)
        {
            await Mediator.Send(new DeleteCompanyInfoCommand { Id = id }, cancellationToken);

            return NoContent();
        }
    }
}
