using InvoiceManagementSystem.Application.Features.Clients.Command;
using InvoiceManagementSystem.Application.Features.Clients.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.WebAPI.Controllers
{
    public class ClientsController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetClients(CancellationToken cancellationToken)
        {
            return HandleResult(await Mediator.Send(new GetClientListQuery(), cancellationToken));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClient(int id, CancellationToken cancellationToken)
        {
            return HandleResult(await Mediator.Send(new GetClientByIdQuery { Id = id }, cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> CreateClient(CreateClientCommand command, CancellationToken cancellationToken)
        {
            return HandleResult(await Mediator.Send(command, cancellationToken));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClient(int id, EditClientCommand command, CancellationToken cancellationToken)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            return HandleResult(await Mediator.Send(command, cancellationToken));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id, CancellationToken cancellationToken)
        {
            return HandleResult(await Mediator.Send(new DeleteClientCommand { Id = id }, cancellationToken));
        }
    }
}
