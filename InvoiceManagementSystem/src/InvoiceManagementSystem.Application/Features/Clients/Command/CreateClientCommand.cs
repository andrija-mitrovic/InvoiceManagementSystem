using InvoiceManagementSystem.Application.DTOs;
using MediatR;

namespace InvoiceManagementSystem.Application.Features.Clients.Command
{
    public class CreateClientCommand : IRequest<Unit>
    {
        public ClientDto Client { get; set; }
    }
}
