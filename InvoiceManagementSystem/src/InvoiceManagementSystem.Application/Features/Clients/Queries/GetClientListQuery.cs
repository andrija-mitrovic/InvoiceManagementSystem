using InvoiceManagementSystem.Application.DTOs;
using InvoiceManagementSystem.Application.Helpers;
using MediatR;
using System.Collections.Generic;

namespace InvoiceManagementSystem.Application.Features.Clients.Queries
{
    public class GetClientListQuery : IRequest<Result<List<ClientDto>>>
    {
    }
}
