using InvoiceManagementSystem.Application.DTOs;
using MediatR;
using System.Collections.Generic;

namespace InvoiceManagementSystem.Application.Features.Clients.Queries
{
    public class GetClientListQuery : IRequest<List<ClientDto>>
    {
    }
}
