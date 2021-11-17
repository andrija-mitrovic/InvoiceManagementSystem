using InvoiceManagementSystem.Application.DTOs;
using InvoiceManagementSystem.Application.Helpers;
using MediatR;
using System.Collections.Generic;

namespace InvoiceManagementSystem.Application.Features.Invoices.Queries
{
    public class GetUserInvoiceListQuery : IRequest<Result<List<InvoiceDto>>>
    {
        public string User { get; set; }
    }
}
