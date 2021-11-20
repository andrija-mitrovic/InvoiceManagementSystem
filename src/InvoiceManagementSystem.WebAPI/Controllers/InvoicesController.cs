using InvoiceManagementSystem.Application.DTOs;
using InvoiceManagementSystem.Application.Features.Invoices.Command;
using InvoiceManagementSystem.Application.Features.Invoices.Queries;
using InvoiceManagementSystem.Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.WebAPI.Controllers
{
    public class InvoicesController : BaseApiController
    {
        private readonly ICurrentUserService _currentUserService;

        public InvoicesController(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }

        [HttpGet]
        public async Task<ActionResult<List<InvoiceDto>>> GetInvoicesByCreatedUser(CancellationToken cancellationToken)
        {
            return await Mediator.Send(new GetUserInvoiceListQuery { User = _currentUserService.UserId }, cancellationToken);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InvoiceDto>> GetInvoiceById(int id, CancellationToken cancellationToken)
        {
            return await Mediator.Send(new GetInvoiceByIdQuery { Id = id }, cancellationToken);
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> AddInvoice(CreateInvoiceCommand command, CancellationToken cancellationToken)
        {
            return await Mediator.Send(command, cancellationToken);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> DeleteInvoice(int id, EditInvoiceCommand command, CancellationToken cancellationToken)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command, cancellationToken);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> DeleteInvoice(int id, CancellationToken cancellationToken)
        {
            await Mediator.Send(new DeleteInvoiceCommand { Id = id }, cancellationToken);

            return NoContent();
        }
    }
}
