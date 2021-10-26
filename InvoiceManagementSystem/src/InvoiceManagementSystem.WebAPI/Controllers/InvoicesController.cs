using InvoiceManagementSystem.Application.DTOs;
using InvoiceManagementSystem.Application.Features.Invoices.Command;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.WebAPI.Controllers
{
    public class InvoicesController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> AddInvoice(InvoiceDto invoiceDto, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateInvoiceCommand { Invoice = invoiceDto }, cancellationToken));
        }
    }
}
