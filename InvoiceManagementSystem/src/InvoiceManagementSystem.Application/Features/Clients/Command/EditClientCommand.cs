using InvoiceManagementSystem.Application.DTOs;
using InvoiceManagementSystem.Application.Helpers;
using MediatR;

namespace InvoiceManagementSystem.Application.Features.Clients.Command
{
    public class EditClientCommand : IRequest<Result<Unit>>
    {
        public int Id { get; set; }
        public ClientDto Client { get; set; }
    }
}
