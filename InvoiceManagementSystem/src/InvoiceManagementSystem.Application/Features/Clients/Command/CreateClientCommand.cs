using InvoiceManagementSystem.Application.DTOs;
using InvoiceManagementSystem.Application.Helpers;
using MediatR;

namespace InvoiceManagementSystem.Application.Features.Clients.Command
{
    public class CreateClientCommand : IRequest<Result<Unit>>
    {
        public ClientDto Client { get; set; }
    }
}
