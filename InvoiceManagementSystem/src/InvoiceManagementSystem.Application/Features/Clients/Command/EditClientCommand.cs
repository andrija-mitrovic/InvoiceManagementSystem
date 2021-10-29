using InvoiceManagementSystem.Application.DTOs;
using MediatR;

namespace InvoiceManagementSystem.Application.Features.Clients.Command
{
    public class EditClientCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public ClientDto Client { get; set; }
    }
}
