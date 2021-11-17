using InvoiceManagementSystem.Application.DTOs;
using InvoiceManagementSystem.Application.Features.Invoices.Command;
using InvoiceManagementSystem.Application.Features.Invoices.Queries;
using InvoiceManagementSystem.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> GetInvoicesByCreatedUser(CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetUserInvoiceListQuery { User = _currentUserService.UserId }, cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> AddInvoice(CreateInvoiceCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }
    }
}
