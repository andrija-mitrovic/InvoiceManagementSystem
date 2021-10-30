using InvoiceManagementSystem.Application.DTOs;
using MediatR;

namespace InvoiceManagementSystem.Application.Features.Clients.Queries
{
    public class GetClientByIdQuery : IRequest<ClientDto>
    {
        public int Id { get; set; }
    }
}
