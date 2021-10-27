using InvoiceManagementSystem.Application.DTOs;
using MediatR;
using System.Collections.Generic;

namespace InvoiceManagementSystem.Application.Features.Invoices.Queries
{
    public class GetUserInvoiceListQuery : IRequest<List<InvoiceDto>>
    {
        public string User { get; set; }
    }
}
