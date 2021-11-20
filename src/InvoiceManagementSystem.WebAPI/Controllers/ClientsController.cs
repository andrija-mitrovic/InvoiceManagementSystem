using InvoiceManagementSystem.Application.DTOs;
using InvoiceManagementSystem.Application.Features.Clients.Command;
using InvoiceManagementSystem.Application.Features.Clients.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.WebAPI.Controllers
{
    public class ClientsController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<ClientDto>>> GetClients(CancellationToken cancellationToken)
        {
            return await Mediator.Send(new GetClientListQuery(), cancellationToken);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClientDto>> GetClient(int id, CancellationToken cancellationToken)
        {
            return await Mediator.Send(new GetClientByIdQuery { Id = id }, cancellationToken);
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> CreateClient(CreateClientCommand command, CancellationToken cancellationToken)
        {
            return await Mediator.Send(command, cancellationToken);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> UpdateClient(int id, EditClientCommand command, CancellationToken cancellationToken)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command, cancellationToken);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> DeleteClient(int id, CancellationToken cancellationToken)
        {
            await Mediator.Send(new DeleteClientCommand { Id = id }, cancellationToken);

            return NoContent();
        }
    }
}
