using InvoiceManagementSystem.Application.DTOs;
using InvoiceManagementSystem.Application.Helpers;
using MediatR;

namespace InvoiceManagementSystem.Application.Features.Clients.Queries
{
    public class GetClientByIdQuery : IRequest<Result<ClientDto>>
    {
        public int Id { get; set; }
    }
}
